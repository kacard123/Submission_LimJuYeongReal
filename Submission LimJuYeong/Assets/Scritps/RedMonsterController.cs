using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMonsterController : MonoBehaviour
{
    void Start()
    {
        //redmonsterRigidbody = GetComponent<Rigidbody>();
    }
    public void Die()
    {
        // ?????? ???? ?????????? ????????
        gameObject.SetActive(false);
    }
}
