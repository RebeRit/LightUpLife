using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monster_Script : MonoBehaviour
{
    void OnInvoke()

    {

        //�� �ڵ忡 ���� 1�� �ڿ� �Ʒ��� ���� �α� ����.

        SceneManager.LoadScene("5_Chapter2");

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            /* �÷��̾ ���� collider�� �浹�ϸ� ��ũ��Ʈ ���
             �̶� �÷��̾ �Ѿ� �߻� �����ϰ� �ڵ�. ���� ������
            ������ ����... �����̵� ������ ����ȯ*/
            Debug.Log("�̳༮�� �Ƴ׸�װ� ��ƴ޶�� �����ΰ�? ������ ��.. ���ⰰ���� ���� ���������� ������!!!");
            Invoke("OnInvoke", 3.0f); //�̰� ���� ����� ��ũ��Ʈ ����� ����ȯ �ڵ�� �ٲܰ���

        }
    }
}
