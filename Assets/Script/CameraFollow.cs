using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //카메라가 따라갈 상대
    [SerializeField] public Transform target;
    //카메라가 부드럽게, 멈추는 데 걸리는 시간
    public float smoothTime = 0.3f;
    //SmoothDamp()가 참고하는 속도. 계산한 값을 이 변수에 넣으면서 서서히 카메라가 움직이는 속도를 줄일 것.
    public Vector3 _currentVelocity = new Vector3(0, 0, 0);
    // 카메라와 플레이어 사이의 거리 (오프셋)
    public Vector3 offset;

    private void Awake()
    {
        offset = new Vector3(0, transform.position.y, transform.position.z);
    }

    private void LateUpdate()
    {

        Vector3 desiredPosition = target.position + offset;

        transform.position = Vector3.SmoothDamp(
            transform.position,     // 현재 위치
            desiredPosition,         // 목표 위치
            ref _currentVelocity,   // 참조로 전달된 현재 속도
            smoothTime              // 부드러운 이동 시간
            );
    }

}