using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot_Script : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag== "Player")
        {
            /*��ũ��Ʈ ��� 
            �Ƴ׸�׸� ������ �ƴ�.
            �Ƴ׸�װ� ���� �ʾȿ� �ִ� ���� �Ѹ��� ��ƴ޶� ��Ź
            �������� �����ϴ� ���� ��ũ��Ʈ ���*/
            Debug.Log("�ʰ� ��...!");

        }
    }
}
