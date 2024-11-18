using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //ī�޶� ���� ���
    [SerializeField] public Transform target;
    //ī�޶� �ε巴��, ���ߴ� �� �ɸ��� �ð�
    public float smoothTime = 0.3f;
    //SmoothDamp()�� �����ϴ� �ӵ�. ����� ���� �� ������ �����鼭 ������ ī�޶� �����̴� �ӵ��� ���� ��.
    public Vector3 _currentVelocity = new Vector3(0, 0, 0);
    // ī�޶�� �÷��̾� ������ �Ÿ� (������)
    public Vector3 offset;

    private void Awake()
    {
        offset = new Vector3(0, transform.position.y, transform.position.z);
    }

    private void LateUpdate()
    {

        Vector3 desiredPosition = target.position + offset;

        transform.position = Vector3.SmoothDamp(
            transform.position,     // ���� ��ġ
            desiredPosition,         // ��ǥ ��ġ
            ref _currentVelocity,   // ������ ���޵� ���� �ӵ�
            smoothTime              // �ε巯�� �̵� �ð�
            );
    }

}