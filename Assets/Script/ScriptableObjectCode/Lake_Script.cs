using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lake_Script : MonoBehaviour
{
    void OnInvokeL()
    // ȣ���� ������ 3�ʵ� �ͻ��Ͽ� �� ���ε�Ǵ� �ڵ�
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            /*���ε� �� */
            Debug.Log("�ͻ��մϴ�");
            Invoke("OnInvokeL", 3.0f);

        }
    }
}
