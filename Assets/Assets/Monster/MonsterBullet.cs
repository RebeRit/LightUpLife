using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MonsterBullet : MonoBehaviour
{
    public GameObject player;
    public float disappear_time = 10f; //�Ѿ��� �߻�� �� �ִ� ���� �ð�
    public float speed = 30f; //�Ѿ��� �ӵ�
    private double timer = 0.0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        timer = disappear_time;
    }

    // Update is called once per frame
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

        if (other.CompareTag("Player"))
        {
            Debug.Log("�¾Ҵ�!!");
            player.GetComponent<Player_Script>().Damage(2);
            Destroy(this.gameObject);

        }

        if (other.CompareTag("Walls"))
        {
            Destroy(this.gameObject);
        }
    }
}
