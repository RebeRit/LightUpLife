using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Moving : MonoBehaviour
{
    public Transform GP_target; //����ٴ� ������Ʈ�� ��ġ
    private Transform GP_target_me; //ī�޶� �ڽ��� ��ġ

    void Start()
    {
        this.transform.position = new Vector3(0, 5, 5); //��ġ �ʱ�ȭ
        this.transform.rotation = Quaternion.Euler(45, 180, 0); //���� �ʱ�ȭ
        GP_target_me = GetComponent<Transform>(); //��ũ��Ʈ�� ����� ��ü�� ��ġ�� ����
    }

    void Update()
    {
        GP_target_me.position = new Vector3(GP_target.position.x, 15.34f, GP_target.position.z + 7.48f); //target�� ��ġ���� z���� -10�� ������ ī�޶� ����ٴ�
    }
}
