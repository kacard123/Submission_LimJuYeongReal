using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_x2 : MonoBehaviour
{
    // �ӵ� �̹��� 
    public Sprite x1;
    public Sprite x2;

    // ���� �ӵ� ���� Ȯ�� (������ �������� = ��ư�� ���ȴ��� �� ���ȴ���)
    public bool isdouble = false;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(onClick); // onclick �̶�� �޼��带 ��ư���� �ҷ��´�.
    }

    private void onClick() // Ŭ������ ��
    {
        if (isdouble == false) // �ι谡 �ƴ϶��
        {
            //isdouble = true; // 2������� �ֱ�
            Time.timeScale = 2f; 
            GetComponent<Image>().sprite = x2; // X2 �̹����� �����´�
        }
        else
        {
            //isdouble = false; 
            Time.timeScale = 1f; // �Ϲ� �ӵ�
            GetComponent<Image>().sprite = x1; // x1 �̹����� �����´�
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
    //        // 2���
    //        ct.isFastSpeed = true;
    //        Time.timeScale = 2f;
    //        spriteRenderer.sprite = x2;
    //    }
    //    // 1���
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
