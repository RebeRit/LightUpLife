using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public Slider PlayerHpSlider;
    public float Damage;

    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKey(KeyCode.H))
        {
            //PlayerHealthBar.value -= 0.1f;
            PlayerHpSlider.value -= Damage;
        }
        
    }
}
// �̰� h������ �ϴ°Ŷ� ������ �����ҵ�. moving AI���� �ǰ����ҵ� ����