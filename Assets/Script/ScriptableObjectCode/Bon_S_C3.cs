using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bon_S_C3 : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            /*��ũ��Ʈ ��� 
            �߰��� 
            �� ���̸� �ֺ� ������ ������±���! ���� ��ũ��Ʈ ������ ���ڴٸ� �ϴ��� ������� */
            Debug.Log("������ ������ EZ");

        }
    }
}
