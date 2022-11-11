using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mPosition = Camera.main.WorldToScreenPoint(this.transform.position); //����ī�޶��� ��ġ ������ mPosition�� ����
        this.transform.LookAt(new Vector3(-(-Input.mousePosition.x + mPosition.x), 0, -(-Input.mousePosition.y + mPosition.y)));
    }
}
