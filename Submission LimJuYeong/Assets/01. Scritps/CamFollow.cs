using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public enum State
    {
        // 3?? ??? ?
        Idle, Ready, Tracking
    }

    // ???? ??
    private State state
    {
        set
        {
            switch (value)
            {
                case State.Idle:
                    break;
                case State.Ready:
                    break;
                case State.Tracking:
                    break;
            }
        }
    }

    void Awake()
    {
        state = State.Idle;
    }

    private Transform target;
    // ??? ??? ? ??? ?????? 

    public float smoothTime = 0.2f;
    // ??? ??? ? ?? ???? ? ??? ????? ???? ??? ???? ?? ??
    // ???? ??? ?? ???? ? Vector3 ??? ?? ?? ? ???? ???? ??? ??? ??


    private Vector3 lastMovingVelocity;
    // ????? ??? ??? ??? ???? ?? ???? ?? ??? ???? ???? ?? ??? ????
    // ?? ???? ?? 
    private Vector3 targetPosition;
    // ?? ?? ??? ????? ??? ???? ???? ??? ???? 

    private Camera cam;
    private float targetZoomSize = 5f;

    private const float roundReadyZoomSize = 14.5f;
    private const float readyShotZoomSize = 5f;
    private const float trackingZoomSize = 10f;

    private float lastZoomSpeed;

    private State state
    {
        set
        {
            switch (value)
            {
                case State.Idle:
                    targetZoomSize = roundReadyZoomSize; //??
                    break;
                case State.Ready:
                    targetZoomSize = readyShotZoomSize; //??
                    break;
                case State.Tracking:
                    targetZoomSize = trackingZoomSize; //??
                    break;
            }
        }
    }

    void Awake()
    {
        cam = GetComponentInChildren<Camera>(); //??
        state = State.Idle;
    }

    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
    }

    //???? ?? ???? ??
    private void Move()
    {
        targetPosition = target.transform.position;

        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPosition,
                                            ref lastMovingVelocity, smoothTime);

        transform.position = smoothPosition;

        state = State.Tracking;
    }

    private void Zoom()
    {
        float smoothZoomSize = Mathf.SmoothDamp(cam.orthographicSize, targetZoomSize,
                                            ref lastZoomSpeed, smoothTime);

        cam.orthographicSize = smoothZoomSize;
    }

    private void FixedUpdate() // FixedUpdate? ??? ??? ??? ? ?? 
    {
        if (target != null)
        {
            Move();
            Zoom();
        }
    }
}