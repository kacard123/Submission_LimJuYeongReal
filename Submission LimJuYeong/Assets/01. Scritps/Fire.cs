using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    public float speed;

    public float distance;
    public LayerMask isLayer;


    private void Start()
    {
        // DestroyBullet �Լ��� 2�� �Ŀ� �����Ѵ�
        Invoke("DestroyBullet", 2);
    }

    void Update()
    {
        //RaycastHit2D ray = Physics.Raycast(transform.position, transform.right, distance, isLayer);
        //if(ray.collider != null)

        // ��ó�� ������ �� �Ҳ��� ������ transform.rotation.y�� 0
        // �ʴ� ���ǵ��� �ӵ��� ���������� ���ư���
        if (transform.rotation.y == 0)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);

        }


    }

    void DestroyBullet()
    {
        // 3�� �ڿ� �ڽ��� ���� ������Ʈ �ı�
        Destroy(gameObject, 3f);
    }

    // Ʈ���� �浹 �� �ڵ����� ����Ǵ� �޼���
    void OnTriggerEnter2D(Collider2D other)
    {
        // �浹�� ���� ���� ������Ʈ�� Player �±׸� ���� ���
        if (other.tag == "Spark")
        {
            // ���� ���� ������Ʈ���� RedMonsterController ������Ʈ ��������
            RedMonsterController redMonsterController = other.GetComponent<RedMonsterController>();

            // �������κ��� RedMonsterController ������Ʈ�� �������� �� �����ߴٸ�
            if (redMonsterController != null)
            {
                // ���� RedMonsterController ������Ʈ�� Die() �޼��� ����
                redMonsterController.Die();
                DestroyBullet();
            }
        }
    }
}