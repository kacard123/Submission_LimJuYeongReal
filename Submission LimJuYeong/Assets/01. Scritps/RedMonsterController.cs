using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMonsterController : MonoBehaviour
{
    private Rigidbody redMonsterRigidbody; // �̵��� ����� ������ٵ� ������Ʈ

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
