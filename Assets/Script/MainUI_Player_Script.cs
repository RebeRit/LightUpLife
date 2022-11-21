using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI_Player_Script : MonoBehaviour
{
    public float speed = 5f; //�÷��̾�� ĳ������ �̵��ӵ�
    Animator animator;
    public GameObject Front_Block;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Transform>();
        animator = this.GetComponent<Animator>();
        Front_Block.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1);
    }

    // Update is called once per frame
    void Update()
    {
        //�̵�����
        if (Input.GetKey(KeyCode.A)) //���� �̵�
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World); //cpu������ ���� ������ �ؼ��ϱ� ���� Time.deltaTime�� ���ؼ� ��� // Space.World : ������ǥ
            animator.SetFloat("IsMoving", 1f);
            if (Input.GetKey(KeyCode.W))
            {
                Front_Block.transform.position = new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z + 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Front_Block.transform.position = new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z - 1);
            }
            else
            {
                Front_Block.transform.position = new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z);
            }
        }
        if (Input.GetKey(KeyCode.D)) //������ �̵�
        {
            transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
            animator.SetFloat("IsMoving", 1f);
            if (Input.GetKey(KeyCode.W))
            {
                Front_Block.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z + 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Front_Block.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z - 1);
            }
            else
            {
                Front_Block.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z);
            }
        }
        if (Input.GetKey(KeyCode.W)) //���� �̵�
        {
            transform.Translate(0, 0, speed * Time.deltaTime, Space.World);
            animator.SetFloat("IsMoving", 1f);
            if (Input.GetKey(KeyCode.A))
            {
                Front_Block.transform.position = new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z + 1);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                Front_Block.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z + 1);
            }
            else
            {
                Front_Block.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1);
            }
        }
        if (Input.GetKey(KeyCode.S)) //�Ʒ��� �̵�
        {
            transform.Translate(0, 0, -speed * Time.deltaTime, Space.World);
            animator.SetFloat("IsMoving", 1f);
            if (Input.GetKey(KeyCode.A))
            {
                Front_Block.transform.position = new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z - 1);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                Front_Block.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z - 1);
            }
            else
            {
                Front_Block.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 1);
            }
        }
        if ((!Input.GetKey(KeyCode.A)) && (!Input.GetKey(KeyCode.D)) && (!Input.GetKey(KeyCode.W)) && (!Input.GetKey(KeyCode.S))) //�������� ���� ��
        {
            animator.SetFloat("IsMoving", 0f);
        }

        //��������
        this.transform.LookAt(Front_Block.transform);

    }
}
