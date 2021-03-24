using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TWEEN : MonoBehaviour
{
    private Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        //efeitos
        object p = img.DOFade(0, 80);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
