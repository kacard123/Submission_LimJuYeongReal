using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class FireSpawner : MonoBehaviour
//{
//    public GameObject firePrefab; // ������ ź���� ���� ������
//    public float spawnRateMin = 0.5f; // �ּ� ���� �ֱ�
//    public float spawnRateMax = 3f; // �ִ� ���� �ֱ�

//    private Transform target; // �߻��� ���
//    private float spawnRate; // ���� �ֱ�
//    private float timeAfterSpawn; // �ֱ� ���� �������� ���� �ð�

//    void Start()
//    {
//        // �ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
//        // timeAfterSpawn = 0f;
//        // ź�� ���� ������ spawnRateMin�� spawnRateMAx ���̿��� ���� ����
//        // spawnRate = Random.Range(spawnRateMin, spawnRateMax);
//        // RedMonster Controller ������Ʈ�� ���� ���� ������Ʈ�� ã�� ���� ������� ����
//        // target = FindObjectOfType<RedMonsterController>().transform;
//    }

//    void Update()
//    {
//        // timeAfterSpawn ����
//        timeAfterSpawn += Time.deltaTime;

//        // �ֱ� ���� ������������ ������ �ð��� ���� �ֱ⺸�� ũ�ų� ���ٸ� 
//        if(timeAfterSpawn >= spawnRate)
//        {
//            // ������ �ð��� ����
//            timeAfterSpawn = 0f;

//            // bulletPrefab�� ��������
//            // transform.position ��ġ�� transform.rotation ȸ������ ����
//            GameObject fire = Instantiate(firePrefab, transform.position, transform.rotation);
//            // ������ bullet ���� ������Ʈ�� ���� ������ target�� ���ϵ��� ȸ��
//            fire.transform.LookAt(target);

//            // ������ ���� ������ spawnRateMin, spawnRateMax ���̿��� ���� ���� 
//            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
//        }
//    }
//}
