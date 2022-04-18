using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� �Ѿ˻����⿡�� ����ߴ� �����
// �Ź� �ʿ�ø��� ����ߴ� 'Instantiate'(����) ����� �ƴ�
// ������Ʈ Ǯ�� ����� ����� ��
// ������Ʈ Ǯ��(Object Pulling)?
// ���� �ʱ⿡ �ʿ��Ѹ�ŭ ������Ʈ���� �̸� �����
// 'Ǯ(Pool) : ������'�� �׾Ƶδ� ����̴�.
// �� �ش� ����� �ʿ��ϳ�
// Instantiate() �޼���ó�� ������Ʈ�� �ǽð����� �����ϰų�
// Destroy() �޼���ó�� ������Ʈ�� �ǽð����� �ı��ϴ� 
// ó���� ������ ���� �䱸�Ѵ�.
// ���� �޸𸮸� �����ϴ� GC(������ �÷���)�����ϱ� ����.
// ���� ���߿� ������Ʈ�� �ʹ� ���� �����ϰų�
// ���� ����(������) ������ �߻��� �˴ϴ�.

// ������ �����ϰ� �ֱ������� ���ġ�ϴ� ��ũ��Ʈ
public class Platform3Spawner : MonoBehaviour
{
    // ������ ������ ���� ������
    public GameObject platformPrefab;
    // ������ ���� ��
    public int count = 4;

    // ���� ��ġ������ �ð� ���� �ּڰ�
    public float timeBetSpawnMin = 2.25f;
    // ���� ��ġ������ �ð� ���� �ִ밪
    public float timeBetSpawnMax = 3.25f;
    //���� ��ġ������ �ð� ���� 
    private float timeBetSpawn;

    // ��ġ�� ��ġ�� �ּ� y��
    public float yMin = -7.5f;
    // ��ġ�� ��ġ�� �ִ� y��
    public float yMax = 4.5f;
    // ��ġ�� ��ġ�� x��
    private float xPos = 20f;

    // �̸� ������ ���ǵ��� ������ �迭
    private GameObject[] platforms;
    // ����� ���� ������ ����
    private int currentIndex = 0;

    // �ʹݿ� ������ ������ ȭ�� �ۿ� ���ܵ� ��ġ
    private Vector2 poolPosition = new Vector2(0, -25);
    // ������ ��ġ ����
    private float lastSpawnTime;


    void Start()
    {
        // ������ �ʱ�ȭ�ϰ� ����� ������ �̸� ����

        // count��ŭ�� ������ ������ ���ο� ���� �迭 ����
        platforms = new GameObject[count];

        // count��ŭ �����ϸ鼭 ���� ����
        for (int i = 0; i < count; i++)
        {
            // platformPrefab�� �������� �� ������
            // poolPosition��ġ�� ���� ����
            // ������ ������ platforms �迭�� �Ҵ�
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);


        }

        // ������ ��ġ ���� �ʱ�ȭ
        lastSpawnTime = 0f;
        // ������ ��ġ������ �ð� ������ �ʱ�ȭ
        timeBetSpawn = 0f;

    }


    void Update()
    {
        // ������ ���ư��� �ֱ������� ������ ��ġ

        // ���ӿ��� ���¿����� �������� �ʴ´�.
        if (GameManager.instance.isGameover) return;

        // ������ ��ġ �������� timeBetSpawn �̻� �ð��� �귶�ٸ�,
        if (Time.time >= lastSpawnTime + timeBetSpawn)
        {
            // ��ϵ� ������ ��ġ ������ ���� �������� ����
            lastSpawnTime = Time.time;

            // ���� ��ġ������ �ð� ������ timeBetSpawnMin,
            // timeBetSpawnMax ���̿��� ���� ��������
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);

            // ��ġ�� ��ġ�� ���̸� yMin�� yMax ���̿��� ���� ��������
            float yPos = Random.Range(yMin, yMax);

            // ����� ���� ������ ���� ���� ������Ʈ�� ��Ȱ���ϰ�
            // �ٷ� ��� �ٽ� Ȱ��ȭ��Ų��. �� ��, ������ Platform ������Ʈ��
            // OnEnable �޼��尡 �����
            //platforms[currentIndex].SetActive(false);
            //platforms[currentIndex].SetActive(true);

            // ���� ������ ������ ȭ�� �����ʿ� ���ġ
            platforms[currentIndex].transform.position = new Vector2(xPos, yPos);

            // ���� �ѱ��
            currentIndex++;

            // ������ ������ �����ߴٸ�..
            if (currentIndex >= count)
            {
                currentIndex = 0;
            }



        }

    }
}
