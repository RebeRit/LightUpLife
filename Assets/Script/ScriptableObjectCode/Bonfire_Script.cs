using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire_Script : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            /*��ũ��Ʈ ��� 
            �̰��� �Ƴ׸�װ� ���� �����̱���
            ���� ������� ��ũ��Ʈ*/
            Debug.Log("�̰��� ������ �Ա�!");

        }
    }
}
