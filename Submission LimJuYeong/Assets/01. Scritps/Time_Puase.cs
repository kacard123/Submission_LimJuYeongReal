using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_Puase : MonoBehaviour
{
    public Sprite pause;
    public Sprite unpause;

    ControllerTime ct;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        // pause
        if(ct.isPause == false)
        {
            ct.isPause = true;
            Time.timeScale = 0f;
            spriteRenderer.sprite = unpause;
        }

        // un-pause
        else
        {
            ct.isPause = false;
            Time.timeScale = 1f;
            spriteRenderer.sprite = pause;
        }
    }
}
