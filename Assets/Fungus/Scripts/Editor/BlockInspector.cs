// This code is part of the Fungus library (https://github.com/snozbot/fungus)
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;
using UnityEngine.Serialization;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

namespace Fungus.EditorUtils
{
    /// <summary>
    /// Temp hidden object which lets us use the entire inspector window to inspect the block command list.
    /// </summary>
    public class BlockInspector : ScriptableObject 
    {
        [FormerlySerializedAs("sequence")]
        public Block block;
    }

    /// <summary>
    /// Custom editor for the temp hidden object.
    /// </summary>
    [CustomEditor (typeof(BlockInspector), true)]
    public class BlockInspectorEditor : Editor
    {
        protected Vector2 blockScrollPos;
        protected Vector2 commandScrollPos;
        protected bool resize = false;
        protected bool clamp = false;
#if UNITY_2019_1_OR_NEWER
        protected float topPanelHeight = 0;
#else
        protected float topPanelHeight = 48;
#endif
        protected float windowHeight = 0f;

        // Cache the block and command editors so we only create and destroy them
        // when a different block / command is selected.
        protected BlockEditor activeBlockEditor;
        protected CommandEditor activeCommandEditor;
        protected Command activeCommand; // Command currently being inspected

        // Cached command editors to avoid creating / destroying editors more than necessary
        // This list is static so persists between 
        protected static List<CommandEditor> cachedCommandEditors = new List<CommandEditor>();

        protected void OnDestroy()
        {
            ClearEditors();
        }

        protected void OnEnable()
        {
            ClearEditors();
        }

        protected void OnDisable()
        {
            ClearEditors();
        }

        protected void ClearEditors()
        {
            foreach (CommandEditor commandEditor in cachedCommandEditors)
            {
                DestroyImmediate(commandEditor);
            }

            cachedCommandEditors.Clear();
            activeCommandEditor = null;
        }

        public override void OnInspectorGUI () 
        {
            BlockInspector blockInspector = target as BlockInspector;
            if (blockInspector.block == null)
            {
                return;
            }

            var block = blockInspector.block;
            if (block == null)
            {
                return;
            }

            var flowchart = (Flowchart)block.GetFlowchart();

            if (flowchart.SelectedBlocks.Count > 1)
            {
                GUILayout.Label("Multiple blocks selected");
                return;
            }

            //if there is no selection but we are drawing, fix that
            if (flowchart.SelectedBlocks.Count == 0)
            {
                flowchart.AddSelectedBlock(block);
            }

            if (activeBlockEditor == null ||
                !block.Equals(activeBlockEditor.target))
            {
                DestroyImmediate(activeBlockEditor);
                activeBlockEditor = Editor.CreateEditor(block, typeof(BlockEditor)) as BlockEditor;
            }

            UpdateWindowHeight();

            float width = EditorGUIUtility.currentViewWidth;

            blockScrollPos = GUILayout.BeginScrollView(blockScrollPos, GUILayout.Height(flowchart.BlockViewHeight));
            activeBlockEditor.DrawBlockName(flowchart);
            activeBlockEditor.DrawBlockGUI(flowchart);
            GUILayout.EndScrollView();

            Command inspectCommand = null;
            if (flowchart.SelectedCommands.Count == 1)
            {
                inspectCommand = flowchart.SelectedCommands[0];
            }

            if (Application.isPlaying &&
                inspectCommand != null &&
                !inspectCommand.ParentBlock.Equals(block))
            {
                Repaint();
                return;
            }

            // Only change the activeCommand at the start of the GUI call sequence
            if (Event.current.type == EventType.Layout)
            {
                activeCommand = inspectCommand;
            }

            DrawCommandUI(flowchart, inspectCommand);
        }

        /// <summary>
        /// In Unity 5.4, Screen.height returns the pixel height instead of the point height
        /// of the inspector window. We can use EditorGUIUtility.currentViewWidth to get the window width
        /// but we have to use this horrible hack to find the window height.
        /// For one frame the windowheight will be 0, but it doesn't seem to be noticeable.
        /// </summary>
        protected void UpdateWindowHeight()
        {
            windowHeight = Screen.height * EditorGUIUtility.pixelsPerPoint;
        }

        public void DrawCommandUI(Flowchart flowchart, Command inspectCommand)
        {
            ResizeScrollView(flowchart);

            EditorGUILayout.Space();

            activeBlockEditor.DrawButtonToolbar();

            commandScrollPos = GUILayout.BeginScrollView(commandScrollPos);

            if (inspectCommand != null)
            {
                if (activeCommandEditor == null || 
                    !inspectCommand.Equals(activeCommandEditor.target))
                {
                    // See if we have a cached version of the command editor already,
                    var editors = (from e in cachedCommandEditors where (e != null && (e.target.Equals(inspectCommand))) select e);

                    if (editors.Count() > 0)
                    {
                        // Use cached editor
                        activeCommandEditor = editors.First();
                    }
                    else
                    {
                        // No cached editor, so create a new one.
                        activeCommandEditor = Editor.CreateEditor((Command)inspectCommand) as CommandEditor;
                        cachedCommandEditors.Add(activeCommandEditor);
                    }
                }
                if (activeCommandEditor != null)
                {
                    activeCommandEditor.DrawCommandInspectorGUI();
                }
            }

            GUILayout.EndScrollView();

            // Draw the resize bar after everything else has finished drawing
            // This is mainly to avoid incorrect indenting.
            Rect resizeRect = new Rect(0, flowchart.BlockViewHeight + topPanelHeight, EditorGUIUtility.currentViewWidth, 4f);
            GUI.color = new Color(0.64f, 0.64f, 0.64f);
            GUI.DrawTexture(resizeRect, EditorGUIUtility.whiteTexture);
            resizeRect.height = 1;
            GUI.color = new Color32(132, 132, 132, 255);
            GUI.DrawTexture(resizeRect, EditorGUIUtility.whiteTexture);
            resizeRect.y += 3;
            GUI.DrawTexture(resizeRect, EditorGUIUtility.whiteTexture);
            GUI.color = Color.white;

            Repaint();
        }

        private void ResizeScrollView(Flowchart flowchart)
        {
            Rect cursorChangeRect = new Rect(0, flowchart.BlockViewHeight + 1 + topPanelHeight, EditorGUIUtility.currentViewWidth, 4f);

            EditorGUIUtility.AddCursorRect(cursorChangeRect, MouseCursor.ResizeVertical);
            
            if (cursorChangeRect.Contains(Event.current.mousePosition))
            {
                if (Event.current.type == EventType.MouseDown)
                {
                    resize = true;
                }
            }

            if (resize && Event.current.type == EventType.Repaint)
            {
                Undo.RecordObject(flowchart, "Resize view");
                flowchart.BlockViewHeight = Event.current.mousePosition.y - topPanelHeight;
            }
            
            ClampBlockViewHeight(flowchart);
            
            // Stop resizing if mouse is outside inspector window.
            // This isn't standard Unity UI behavior but it is robust and safe.
            if (resize && Event.current.type == EventType.MouseDrag)
            {
                Rect windowRect = new Rect(0, 0, EditorGUIUtility.currentViewWidth, windowHeight);
                if (!windowRect.Contains(Event.current.mousePosition))
                {
                    resize = false;
                }
            }

            if (Event.current.type == EventType.MouseUp)
            {
                resize = false;
            }
        }
        
        protected virtual void ClampBlockViewHeight(Flowchart flowchart)
        {
            // Screen.height seems to temporarily reset to 480 for a single frame whenever a command like 
            // Copy, Paste, etc. happens. Only clamp the block view height when one of these operations is not occuring.

            if (Event.current.commandName != "")
            {
                clamp = false;
            }
            
            if (clamp)
            {
                // Make sure block view is always clamped to visible area
                float height = flowchart.BlockViewHeight;
                height = Mathf.Max(200, height);
                height = Mathf.Min(windowHeight - 200,height);
                flowchart.BlockViewHeight = height;
            }
            
            if (Event.current.type == EventType.Repaint)
            {
                clamp = true;
            }
        }
    }
}
