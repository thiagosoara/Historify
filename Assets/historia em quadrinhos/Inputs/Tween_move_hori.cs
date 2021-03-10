using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Tween_move_hori : MonoBehaviour
{
    [SerializeField]
    private RectTransform img;
    [SerializeField]
    private float pos;
    [SerializeField]
    private int duract;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<RectTransform>();
        StartCoroutine(MoveX());
    }

    // Update is called once per frame
    IEnumerator MoveX()
    {
        yield return new WaitForSeconds(4);
        img.DOAnchorPosX(pos, duract, true);
    }
}
