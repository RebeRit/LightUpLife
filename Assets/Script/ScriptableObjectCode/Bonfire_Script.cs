using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            //SceneManager.LoadScene("5_Chapter2");

        }
    }
}
