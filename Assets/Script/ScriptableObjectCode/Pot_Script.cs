using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot_Script : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag== "Player")
        {
            /* �÷��̾ �Ƴ׸�װ� �����ִ� ������ ������ ��ũ��Ʈ�� ����ȴ�
            -> ���Ͻ��� ������ ���� ��ü�� �ٷ� �ʿ�����!
            -> (�Ƴ׸��) � �� ������! ���ڱ� ������ ������ �޾� ���� �������. �Ƴ׸�״� ������ ��ô�� ������ Ư���� ����
            -> ���Ͻǿ� ���� �� ������ �ִµ� �� ���͸� ��ƴ޶�� �̾߱� . �׸��� ���콺 Ŭ���ϸ� �� ������ �ڵ� �ٽ�¥��
            �Ѿ��� ���Ͻǿ� �ִ� ���Ϳ� �����ϸ� �߻簡 �����ϰ� �ڵ� */
            Debug.Log("�ʰ� ��...!");

        }
    }
}
