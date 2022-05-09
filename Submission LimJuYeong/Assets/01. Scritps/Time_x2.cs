using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_x2 : MonoBehaviour
{
    // ?? ??? 
    public Sprite x1;
    public Sprite x2;

    // ?? ?? ?? ?? (??? ???? = ??? ???? ? ????)
    public bool isdouble = false;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(onClick);
        // onclick ??? ???? ???? ????.
    }

    private void onClick() // ???? ?
    {
        if (isdouble == false) // ??? ????
        {
            //isdouble = true; // 2???? ??
            Time.timeScale = 2f;
            GetComponent<Image>().sprite = x2; // X2 ???? ????
        }
        else
        {
            //isdouble = false; 
            Time.timeScale = 1f; // ?? ??
            GetComponent<Image>().sprite = x1; // x1 ???? ????
        }
        isdouble = !isdouble; // isdouble = true;? isdouble = false; ?? ??

    }

}
