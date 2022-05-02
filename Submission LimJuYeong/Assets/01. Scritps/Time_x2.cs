using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_x2 : MonoBehaviour
{
    // 속도 이미지 
    public Sprite x1;
    public Sprite x2;

    // 현재 속도 상태 확인 (참인지 거짓인지 = 버튼이 눌렸는지 안 눌렸는지)
    public bool isdouble = false;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(onClick); // onclick 이라는 메서드를 버튼으로 불러온다.
    }

    private void onClick() // 클릭했을 때
    {
        if (isdouble == false) // 두배가 아니라면
        {
            //isdouble = true; // 2배속으로 주기
            Time.timeScale = 2f; 
            GetComponent<Image>().sprite = x2; // X2 이미지로 가져온다
        }
        else
        {
            //isdouble = false; 
            Time.timeScale = 1f; // 일반 속도
            GetComponent<Image>().sprite = x1; // x1 이미지를 가져온다
        }
        isdouble = !isdouble;

    }

    //void Start()
    //{
    //    ct = GameObject.Find("TimeController").GetComponent<ControllerTime>();
    //    spriteRenderer = GetComponent<SpriteRenderer>();
    //}

    //void OnMouseUp()
    //{
    //    if (ct.isPause == false)
    //    {
    //        // 2배속
    //        ct.isFastSpeed = true;
    //        Time.timeScale = 2f;
    //        spriteRenderer.sprite = x2;
    //    }
    //    // 1배속
    //    else
    //    {
    //        ct.isFastSpeed = false;
    //        Time.timeScale = 1f;
    //        spriteRenderer.sprite = x1;
    //    }
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}


}
