using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Move_Horizon_Tween : MonoBehaviour
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

    IEnumerator MoveX()
    {
        yield return new WaitForSeconds(4);
        img.DOAnchorPosX(pos, duract, true);
    }
}
