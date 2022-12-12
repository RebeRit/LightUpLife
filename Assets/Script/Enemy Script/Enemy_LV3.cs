using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

//���Ÿ� ���� �Ѿ� �߻� ��ũ��Ʈ
public class Enemy_LV3: MonoBehaviour
{
    public GameObject bullet;
    public double EE_timer = 0.0;
    public double E_AttackCooldown = 1.0;
    public Slider PlayerHpSlider;
    public bool isCollider = false;

    NavMeshAgent nav_LV3;
    public Transform target;

    void Awake()
    {
        nav_LV3 = GetComponent<NavMeshAgent>();
        nav_LV3.enabled = false; //�׺����

    }

    void Update()
    {
        nav_LV3.SetDestination(target.position);

        if (EE_timer > 0) //Ÿ�̸Ӱ� 0�ʺ��� ũ�� �� �����Ӹ��� Ÿ�̸Ӱ� �پ��
        {
            EE_timer -= Time.deltaTime;
        }
        else //Ÿ�̸Ӱ� 0�ʺ��� ���� ��, �ٶ󺸴� �������� �Ѿ� �߻�
        {
            if (isCollider)
            {
                Instantiate(bullet, this.transform.position, this.transform.rotation);
                EE_timer = E_AttackCooldown;
            }
        }
    }

    void Start()
    {
        nav_LV3.enabled = true;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("�����Ÿ� �ȿ� �÷��̾ �ֽ��ϴ�");
            isCollider = true;

            if (PlayerHpSlider.value <= 0)
            {
                // �̰� ���ε������ �ٲٱ�
                SceneManager.LoadScene("EnemyScene");
            }

        }
    }

    void OnTriggerExit(Collider other)
    {
        isCollider = false;
    }



}
