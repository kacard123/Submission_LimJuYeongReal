using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMonsterController : MonoBehaviour
{
    private Rigidbody redMonsterRigidbody; // �̵��� ����� ������ٵ� ������Ʈ

    void Start() // ������ �������� ��Ҹ� �����ϰ� �Ѵ�.
    {
        redMonsterRigidbody = GetComponent<Rigidbody>();
    }
    public void Die() // ���� �Ѿ� ������ ���� ����
    {
        gameObject.SetActive(false);
    }
}