using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

//���Ÿ� ���� �Ѿ� �߻� ��ũ��Ʈ
public class Enemy_LV3 : MonoBehaviour
{
    public GameObject bullet;
    public double EE_timer = 0.0;
    public double E_AttackCooldown = 1.0;
    public Slider PlayerHpSlider;
    public bool isCollider = false;
    public int stage;
    public float Damage;
    int MaxHP;
    int CurHP;

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
                Instantiate(bullet, this.transform.position + new Vector3(0, 1, 0), this.transform.rotation);

                EE_timer = E_AttackCooldown;
            }
        }

        if (CurHP <= 0)
        {
            Die();
        }
    }

    void Start()
    {
        nav_LV3.enabled = true;
        MaxHP = 5;
        CurHP = MaxHP;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("�����Ÿ� �ȿ� �÷��̾ �ֽ��ϴ�");
            //PlayerHpSlider.value -= Damage;
            isCollider = true;

            if (PlayerHpSlider.value <= 0)
            {
                // �̰� ���ε������ �ٲٱ�
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

        }
    }

    void OnTriggerEnter(Collider other)
    {
        //����� ����
        if (other.tag == "Bullet")
        {
            Debug.Log("���� ü�� = " + CurHP);
            LV3_Damage(1);
        }
    }

    public void SetHP(int hp)
    {
        this.MaxHP = hp;
    }

    void Die()
    {
        this.gameObject.SetActive(false);
    }

    public void LV3_Damage(int damage)
    {
        CurHP -= damage;

    }



}