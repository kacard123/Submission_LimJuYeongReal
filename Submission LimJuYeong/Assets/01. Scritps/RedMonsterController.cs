using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMonsterController : MonoBehaviour
{
    private Rigidbody redMonsterRigidbody; // 이동에 사용할 리지드바디 컴포넌트

    void Start()
    {
        redMonsterRigidbody = GetComponent<Rigidbody>();
    }
    public void Die()
    {
        // ?????? ???? ?????????? ????????
        gameObject.SetActive(false);
    }
}
