using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player"); // game object player을 찾아서 객체에 지정
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PlayerPos = player.transform.position; // 플레이어가 조종중인 게임 오브젝트의 위치를 계산
        transform.position = new Vector3(transform.position.y, PlayerPos.x, transform.position.z); // 플레이어가 조종중인 오브젝트의 y 값만 카메라의 좌표에 넘김
    }
}