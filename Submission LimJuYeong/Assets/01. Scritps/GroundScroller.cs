using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
//{
//    public SpriteRenderer[] tiles;
//    public Sprite[] groundImg;
//    public float speed;

//    void Start()
//    {
//        temp = tiles[0];
//    }

//    SpriteRenderer temp;

//    void Update()
//    {
//        for (int i = 0; i < tiles.Length; i++)
//        {
//            if (-5 >= tiles[i].transform.position.x)
//            {
//                for (int q = 0; q < tiles.Length; q++)
//                {
//                    if (temp.transform.position.x < tiles[q].transform.position.x)
//                        temp = tiles[q];
//                }
//                tiles[i].transform.position = new Vector2(temp.transform.position.x + 1, -0.3f);
//                tiles[i].sprite = groundImg[Random.Range(0,groundImg.Length)];
//            }
//        }
//        for (int i = 0; i < tiles.Length; i++)
//        {
//            tiles[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);
//        }
//    }
//}
//{
//    public SpriteRenderer[] tiles;
//    public Sprite[] groundImg;
//    public float speed;

//    void Start()
//    {
//        temp = tiles[0];
//    }
//    SpriteRenderer temp;

//    void Update()
//    {
//        if (GameManager.instance.isPlay)
//        {
//            for (int i = 0; i < tiles.Length; i++)
//            {
//                if (-5 >= tiles[i].transform.position.x)
//                {
//                    for (int q = 0; q < tiles.Length; q++)
//                    {
//                        if (temp.transform.position.x < tiles[q].transform.position.x)
//                            temp = tiles[q];
//                    }
//                    tiles[i].transform.position = new Vector2(temp.transform.position.x + 1, tiles[i].transform.position.y);
//                    //tiles[i].transform.position.x = temp.transform.position.x;
//                    tiles[i].sprite = groundImg[Random.Range(0, groundImg.Length)];
//                }
//            }
//            for (int i = 0; i < tiles.Length; i++)
//            {
//                tiles[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * GameManager.instance.gameSpeed);
//            }
//        }

//    }
//}

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

{
    // ������ ������ ���� ������
    public GameObject platformPrefab;
    // ������ ���� ��
    public int count = 6;

    // ���� ��ġ������ �ð� ���� �ּڰ�
    public float timeBetSpawnMin = 1.25f;
    // ���� ��ġ������ �ð� ���� �ִ밪
    public float timeBetSpawnMax = 2.25f;
    //���� ��ġ������ �ð� ���� 
    private float timeBetSpawn;

    // ��ġ�� ��ġ�� �ּ� y��
    public float yMin = -3.5f;
    // ��ġ�� ��ġ�� �ִ� y��
    public float yMax = 1.5f;
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

        //// ������ ��ġ �������� timeBetSpawn �̻� �ð��� �귶�ٸ�,
        //if (Time.time >= lastSpawnTime + timeBetSpawn)
        //{
        //    // ��ϵ� ������ ��ġ ������ ���� �������� ����
        //    lastSpawnTime = Time.time;

        //    // ���� ��ġ������ �ð� ������ timeBetSpawnMin,
        //    // timeBetSpawnMax ���̿��� ���� ��������
        //    timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);

        //    // ��ġ�� ��ġ�� ���̸� yMin�� yMax ���̿��� ���� ��������
        //    float yPos = Random.Range(yMin, yMax);

        //    // ����� ���� ������ ���� ���� ������Ʈ�� ��Ȱ���ϰ�
        //    // �ٷ� ��� �ٽ� Ȱ��ȭ��Ų��. �� ��, ������ Platform ������Ʈ��
        //    // OnEnable �޼��尡 �����
        //    platforms[currentIndex].SetActive(false);
        //    platforms[currentIndex].SetActive(true);

        //    // ���� ������ ������ ȭ�� �����ʿ� ���ġ
        //    platforms[currentIndex].transform.position = new Vector2(xPos, yPos);

        //    // ���� �ѱ��
        //    currentIndex++;

        //    // ������ ������ �����ߴٸ�..
        //    if (currentIndex >= count)
        //    {
        //        currentIndex = 0;
        //    }



        //}

    }
}
