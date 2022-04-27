using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab; // 화살 설계도를 넣는 변수 선언
    float span = 1.0f;
    float delta = 0;

    private void Start()
    {
        
    }

    private void Update()
    {
        // Time.deltaTime ==> 앞 프레임과 현재 프레임 사이의 시간 차이
        // Instantiate ==> 매개변수로 프리팹을 전달하면 반환값으로 프리팹 인스턴스를 돌려준다
        // as GameObject ==> 기본적인 Object로 반환하는 것을 강제 형 변환(캐스트)를 통해 GameObject형으로 바꾼다
        this.delta += Time.deltaTime;
        if(this.delta > this.span) // delta가 1초 이상이 되면
        {
            this.delta = 0;
            GameObject go = Instantiate(arrowPrefab) as GameObject;

            // 화살의 x좌표를 -6부터 6 사이에 불규칙하게 위치하도록 랜덤으로 반환
            int px = Random.Range(-6, 7);
            go.transform.position = new Vector3(px, 7, 0);
        }
    }

}
