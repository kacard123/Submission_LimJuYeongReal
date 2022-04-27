using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    GameObject player;

    private Rigidbody arrowRigidbody;

    void Start()
    {
        this.player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // 게임오버 상태에서는 동작하지 않는다.
        if (GameManager.instance.isGameover) return;

        // 프레임마다 등속으로 낙하시킨다
        transform.Translate(0, -0.1f, 0);

        // 화면 밖으로 나오면 오브젝트를 소멸시킨다.
        if(transform.position.y < -5.0f)
        {
            // Destroy(gameObject);
        }

        // 충돌 판정
        Vector2 p1 = transform.position; // 화살의 중심 좌표
        Vector2 p2 = this.player.transform.position; // 플레이어의 중심 좌표

        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f; // 화살 반경
        float r2 = 1.0f; // 플레이어 반경

        if (d < r1 + r2)
        {

            arrowRigidbody = GetComponent<Rigidbody>();

            // 충돌하면 화살을 소멸시킨다.
            Destroy(gameObject);
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

}
