using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float speed = 8f;
    // ź�� �̵� �ӷ�
    private Rigidbody bulletRigidbody;
    // �̵��� ����� ������ٵ� ������Ʈ

    void Start()
    {
        // ���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� bulletRigidbody�� �Ҵ�
        bulletRigidbody = GetComponent<Rigidbody>();
        // ������ٵ��� �ӵ� = ���� ���� * �̵� �ӷ�
        bulletRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 3f);
    }
    

    // Ʈ���� �浹 �� �ڵ����� ����Ǵ� �޼���
    void OnTriggerEnter(Collider other)
    {
        // �浹�� ���� ���� ������Ʈ�� Spark �±׸� ���� ���
        if(other.tag == "Spark")
        {
            // ���� ���� ������Ʈ���� PlayerController ������Ʈ ��������
            RedMonsterController redMonsterController = other.GetComponent<RedMonsterController>();

            // �������κ��� PlayerController ������Ʈ�� �������� �� �����ߴٸ�
            if (redMonsterController != null)
            {
                // ���� PlayerController ������Ʈ�� Die()�޼��� ����
                redMonsterController.Die();

            }
        }
    }

    void Update()
    {
        // �����Ӹ��� ������Ʈ�� ������ǥ�󿡼� ������ 1�� ������ ���ư���
        transform.Translate(Vector3.forward * 1f);
    }


}

