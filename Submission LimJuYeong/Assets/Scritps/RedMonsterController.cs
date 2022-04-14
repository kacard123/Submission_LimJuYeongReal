using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMonsterController : MonoBehaviour
{
    void Start()
    {
        //redmonsterRigidbody = GetComponent<Rigidbody>();
    }
    public void Die()
    {
        // 자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);
    }
}
