using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Move_Tween : MonoBehaviour
{
    [SerializeField]
    private Button btn;
    [SerializeField]
    private Text txtBtn;
    [SerializeField]
    private int duract;
    [SerializeField]
    private float pos;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        txtBtn = GetComponentInChildren<Text>();
        Movecima();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Movecima()
    {
        //Mover
        btn.GetComponent<RectTransform>().DOAnchorPosY(pos, duract, true);
    }
}
