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
        // �ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
}
