﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TweenLOGOMARCA : MonoBehaviour
{
    private Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        //efeitos
        img.DOFade(0, 8);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}