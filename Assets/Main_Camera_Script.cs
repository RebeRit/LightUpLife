using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Camera_Script : MonoBehaviour
{
    public Transform target; //����ٴ� ������Ʈ�� ��ġ
    private Transform target_me; //ī�޶� �ڽ��� ��ġ
    
    void Start()
    {
        this.transform.position = new Vector3(0, 10, -10); //��ġ �ʱ�ȭ
        this.transform.rotation = Quaternion.Euler(45, 0, 0); //���� �ʱ�ȭ
        target_me = GetComponent<Transform>(); //��ũ��Ʈ�� ����� ��ü�� ��ġ�� ����
    }

    void Update()
    {
        target_me.position = new Vector3(target.position.x, target.position.y+10, target.position.z-10); //target�� ��ġ���� z���� -10�� ������ ī�޶� ����ٴ�
    }
}
