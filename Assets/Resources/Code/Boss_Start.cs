using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;

public class Boss_Start : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scriptObj;
    public Text nameObj;
    List<string> scripts = new List<string>();
    List<string> names = new List<string>();
    List<string> portraits = new List<string>();
    int checkScriptLine;
    public GameObject nextStoryBtn;
    public Button nextBtn;
    public GameObject backgroundImg;
    public GameObject characterImg;
    public Image portraitImg;
    public GameObject Click_sound;

    // Start is called before the first frame update
    void Start()
    {
        portraitImg = characterImg.GetComponent<Image>();
        // ��ũ��Ʈ �ۼ��ϴ� ��
        names.Add("�����̼�");
        names.Add("���ΰ�");
        names.Add("�Ƴ׸��");
        names.Add("���ΰ�");
        names.Add("�Ƴ׸��");
        names.Add("���ΰ�");

        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Hero_help");
        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Hero_help");
        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Hero_common");

        scripts.Add("������ ��ü�� �ڵ��� ���� ���� ���ΰ� ������ �ݰ��־���.");
        scripts.Add("�ƴϡ� ����ü �̰� ���� ���� �Ͼ����?");
        scripts.Add("������ ������� ���� ��ȣ�� ��ã�� ���� �� ���� �Դٴ� ����� �˰� �־����� �������� ���� ������� ����Ǿ����Ŷ�");
        scripts.Add("������ �ᱹ�� �̷��� �Ǵ°ɱ�?");
        scripts.Add("�ƴϾ�, �ʶ�� ���ฦ �����߸� �� �־�! �츮 ���ݱ��� �� �غ��� ���ݾ�!");
        scripts.Add("�׷�, �켱�� �ε��� ����!");

        // �Ϲ� �ڵ�
        nextBtn.onClick.AddListener(nextScript);

        checkScriptLine = 0;
        scriptObj.text = "";
        StartCoroutine(Typing(scripts[checkScriptLine]));
        nameObj.text = names[checkScriptLine];
        portraitImg.GetComponent<Image>().sprite = Resources.Load<Sprite>(portraits[checkScriptLine].ToString());
        nextStoryBtn.SetActive(false);
        Invoke("showNextBtn", 2.5f);
    }

    void nextScript()
    {
        if (checkScriptLine < 5)
        {
            Click_sound.GetComponent<AudioSource>().Play();
            ++checkScriptLine;
            scriptObj.text = "";
            StartCoroutine(Typing(scripts[checkScriptLine]));
            nameObj.text = names[checkScriptLine];
            portraitImg.GetComponent<Image>().sprite = Resources.Load<Sprite>(portraits[checkScriptLine]);

            Debug.Log("Show Next Script");
            nextStoryBtn.SetActive(false);
            if (checkScriptLine == 2)
            {
                Invoke("showNextBtn", 4.0f);
            }
            else
            {
                Invoke("showNextBtn", 3.0f);
            }
        }
        else
        {
            Click_sound.GetComponent<AudioSource>().Play();
            backgroundImg.SetActive(false);
            characterImg.SetActive(false);
            nameObj.gameObject.SetActive(false);
            scriptObj.gameObject.SetActive(false);
            nextStoryBtn.SetActive(false);
            Player_Script.is_script_time = false;
        }
    }

    void showNextBtn()
    {
        nextStoryBtn.SetActive(true);
    }

    IEnumerator Typing(string text)
    {
        foreach (char letter in text.ToCharArray())
        {
            scriptObj.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
