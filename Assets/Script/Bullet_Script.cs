using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    public float disappear_time = 10f; //�Ѿ��� �߻�� �� �ִ� ���� �ð�
    public float speed = 30f; //�Ѿ��� �ӵ�
    private double timer = 0.0;
    Material mat;

    void Start()
    {
        timer = disappear_time;
    }


    void Update()
    {
        Vector3 angle = transform.forward;
        transform.position += angle * speed * Time.deltaTime;
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Enemy")
        {
            Debug.Log("�¾Ҵ�!!");
            //other.gameObject.SetActive(false);
            Destroy(this.gameObject);
           
        }

        if (other.tag == "Walls")
        {
            Destroy(this.gameObject);
        }
    }



}