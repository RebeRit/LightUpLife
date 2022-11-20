using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8.0f;
    Rigidbody rb;
    Vector3 playerPosition;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        playerPosition = this.transform.position;
        //�� ��ü�� �����̴� ��Ұ� ������ Rigidbody�� WASD �Ӹ� �ƴ϶�
        //Use gravity�� ����ؼ� �߷������� �Ǳ� ������
        //�߷¿� ���� ��ȭ�� ������ �ص־� �ϴ� ���� ������ ���� ��ġ�� ��� �����ؾ���.

        if (Input.GetKey(KeyCode.W))
        {
            playerPosition += speed * Time.deltaTime * Vector3.forward;
            //��ü�� ��ġ�� ���ŵǸ� �״��� Vector3.forward��� ������ǥ���� '��' ����, �ӵ�, �ð��� 60����1 �� ������ �� 
            //playerPosition�� �����ش�.

            rb.MovePosition(playerPosition);
            //���� movePosition���� ���� ���ŵ� ��ġ�� �̵��� ����.
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerPosition += speed * Time.deltaTime * Vector3.left;

            rb.MovePosition(playerPosition);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerPosition -= speed * Time.deltaTime * Vector3.forward;

            rb.MovePosition(playerPosition);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerPosition -= speed * Time.deltaTime * Vector3.left;

            rb.MovePosition(playerPosition);
        }

        if ((!Input.GetKey(KeyCode.A)) && (!Input.GetKey(KeyCode.D)) && (!Input.GetKey(KeyCode.W)) && (!Input.GetKey(KeyCode.S))) //�������� ���� ��
        {
            animator.SetFloat("IsMoving", 0f);
        }
        else animator.SetFloat("IsMoving", 1f);

        /*rb.velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = Vector3.forward * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = Vector3.left * speed;
        }
        if(Input.GetKey(KeyCode.S))
        {
            rb.velocity = Vector3.back * speed;
        }
        if( Input.GetKey(KeyCode.D))
        {
            rb.velocity = Vector3.right * speed;
        }
        */
        Vector3 mPosition = Camera.main.WorldToScreenPoint(this.transform.position);
        this.transform.LookAt(new Vector3(-(-Input.mousePosition.x + mPosition.x), 0, -(-Input.mousePosition.y + mPosition.y))); 
    }
}
