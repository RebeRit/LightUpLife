using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHp : MonoBehaviour
{
    public Slider PlayerHpSlider;
    public float Damage;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHpSlider.value <= 0)
        {
            // �̰� ���ε������ �ٲٱ�
            //SceneManager.LoadScene("�� �� ��Ҿ�");
        }
    }
}
// �̰� h������ �ϴ°Ŷ� ������ �����ҵ�. moving AI���� �ǰ����ҵ� ����