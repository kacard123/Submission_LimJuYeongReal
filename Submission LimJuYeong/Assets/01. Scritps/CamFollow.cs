using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player"); // game object player�� ã�Ƽ� ��ü�� ����
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PlayerPos = player.transform.position; // �÷��̾ �������� ���� ������Ʈ�� ��ġ�� ���
        transform.position = new Vector3(transform.position.y, PlayerPos.x, transform.position.z); // �÷��̾ �������� ������Ʈ�� y ���� ī�޶��� ��ǥ�� �ѱ�
    }
}