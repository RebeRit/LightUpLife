using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Moving : MonoBehaviour
{
    public Transform GP_target; //����ٴ� ������Ʈ�� ��ġ
    private Transform GP_target_me; //ī�޶� �ڽ��� ��ġ
    public GameObject player;
    void Start()
    {
        player.GetComponent<Transform>();
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 15f, player.transform.position.z + 15f); //��ġ �ʱ�ȭ
        this.transform.rotation = Quaternion.Euler(45, 180, 0); //���� �ʱ�ȭ
        GP_target_me = GetComponent<Transform>(); //��ũ��Ʈ�� ����� ��ü�� ��ġ�� ����
    }

    void Update()
    {
        GP_target_me.position = new Vector3(GP_target.position.x, 15f, GP_target.position.z + 15f); //target�� ��ġ���� z���� -10�� ������ ī�޶� ����ٴ�
    }
}
