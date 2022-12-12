using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy_LV2 : MonoBehaviour
{
    // ���Ͱ� �÷��̾� �ڵ������ϴ� �ڵ� + LV2���� �������ݽ� �����̴� ����
    public Slider PlayerHpSlider;
    public Transform target;
    public float Damage;
    NavMeshAgent nav;
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.enabled = false; //�׺����

    }

    void Update()
    {
        nav.SetDestination(target.position);
    }

    void Start()
    {
        nav.enabled = true; //�׺��ѱ�
    }
    void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {
            Debug.Log("���������� �ް��ֽ��ϴ�");
            PlayerHpSlider.value -= Damage;

        }
    }


}