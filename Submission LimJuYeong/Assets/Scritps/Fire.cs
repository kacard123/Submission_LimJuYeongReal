using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    //public float speed = 8f;
    // ???? ???? ????
    //private Rigidbody bulletRigidbody;
    // ?????? ?????? ?????????? ????????

    //void Start()
    //{
    // ???? ???????????? Rigidbody ?????????? ???? bulletRigidbody?? ????
    //bulletRigidbody = GetComponent<Rigidbody>();
    // ???????????? ???? = ???? ???? * ???? ????
    //bulletRigidbody.velocity = transform.forward * speed;

    //Destroy(gameObject, 3f);
    //}


    // ?????? ???? ?? ???????? ???????? ??????
    //void OnTriggerEnter(Collider other)
    //{
    // ?????? ?????? ???? ?????????? Spark ?????? ???? ????
    //if(other.tag == "Spark")
    // {
    // ?????? ???? ???????????? PlayerController ???????? ????????
    // RedMonsterController redMonsterController = other.GetComponent<RedMonsterController>();

    // ?????????????? PlayerController ?????????? ???????? ?? ??????????
    //if (redMonsterController != null)
    //{
    // ?????? PlayerController ?????????? Die()?????? ????
    //redMonsterController.Die();

    //}
    //}
    //}

    //void Update()
    //{
    // ?????????? ?????????? ?????????????? ?????? 1?? ?????? ????????
    //transform.Translate(Vector3.forward * 1f);
    //}


    //}

    public float speed;

    private void Start()
    {
        Invoke("", 2);

    }

    private void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
    }

}