using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//���Ÿ� ���� �Ѿ� �߻� ��ũ��Ʈ
public class EnemyAttack : MonoBehaviour
{
    public GameObject bullet;
    public double EE_timer = 0.0;
    public double E_AttackCooldown = 2.0;
    public Slider PlayerHpSlider;
    public float B_Damage;


    /*void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            Debug.Log("���Զ�!!");

        }
    }*/

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("�����Ÿ� �ȿ� �÷��̾ �ֽ��ϴ�");
            Instantiate(bullet, this.transform.position, this.transform.rotation);
            EE_timer = E_AttackCooldown;
            PlayerHpSlider.value -= B_Damage;

            if (PlayerHpSlider.value <= 0)
            {
                // �̰� ���ε������ �ٲٱ�
                SceneManager.LoadScene("EnemyScene");
            }

        }
    }
}
