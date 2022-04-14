using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float speed = 8f;
    // 탄알 이동 속력
    private Rigidbody bulletRigidbody;
    // 이동에 사용할 리지드바디 컴포넌트

    void Start()
    {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 bulletRigidbody에 할당
        bulletRigidbody = GetComponent<Rigidbody>();
        // 리지드바디의 속도 = 앞쪽 방향 * 이동 속력
        bulletRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 3f);
    }
    

    // 트리거 충돌 시 자동으로 실행되는 메서드
    void OnTriggerEnter(Collider other)
    {
        // 충돌한 상대방 게임 오브젝트가 Spark 태그를 가진 경우
        if(other.tag == "Spark")
        {
            // 상대방 게임 오브젝트에서 PlayerController 컴포넌트 가져오기
            RedMonsterController redMonsterController = other.GetComponent<RedMonsterController>();

            // 상대방으로부터 PlayerController 컴포넌트를 가져오는 데 성공했다면
            if (redMonsterController != null)
            {
                // 상대방 PlayerController 컴포넌트의 Die()메서드 실행
                redMonsterController.Die();

            }
        }
    }

    void Update()
    {
        // 프레임마다 오브젝트를 로컬좌표상에서 앞으로 1의 힘으로 날아가라
        transform.Translate(Vector3.forward * 1f);
    }


}

