using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;

public class Donggul2_Start : MonoBehaviour
{
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
    public GameObject monster;
    public GameObject Click_sound;

    // Start is called before the first frame update
    void Start()
    {
        portraitImg = characterImg.GetComponent<Image>();
        // ��ũ��Ʈ �ۼ��ϴ� ��
        names.Add("�Ƴ׸��");
        names.Add("���ΰ�");
        names.Add("���ΰ�");
        names.Add("�Ƴ׸��");
        names.Add("���ΰ�");
        names.Add("�Ƴ׸��");

        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Hero_help");
        portraits.Add("Images/Hero_help");
        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Hero_common");
        portraits.Add("Images/Portrait_empty");

        scripts.Add("�ѡ� ���� �� ������ ���Ͱ� �־�! ����� ���ࡦ �� ���� ��°�?");
        scripts.Add("�� ���ʹ� ����? å������ �� ���� ���� �� �Ѱ� ��������");
        scripts.Add("�׸��� �� ����, ������ �� ���� ���� ���� �����ε� �̷��� ��ٰ�?");
        scripts.Add("��ư, �� ���ʹ� �Ʊ� ���� ���� ���ͺ��� �� ���� �������� ������ �־�! ó���ϴµ� ���� �ð��� �ɸ� �ž�.");
        scripts.Add("���� ��, �ټ��̾߸��� �� �ڶ��Ÿ��ϱ�!");
        scripts.Add("����! �׸��� �� �� ��ó�� �����Ȱ� ����... ������!");

        // �Ϲ� �ڵ�
        nextBtn.onClick.AddListener(nextScript);

        checkScriptLine = 0;
        scriptObj.text = "";
        StartCoroutine(Typing(scripts[checkScriptLine]));
        nameObj.text = names[checkScriptLine];
        portraitImg.GetComponent<Image>().sprite = Resources.Load<Sprite>(portraits[checkScriptLine].ToString());
        nextStoryBtn.SetActive(false);
        Invoke("showNextBtn", 2.5f);
        monster.SetActive(false);
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
            if (checkScriptLine == 3)
            {
                Invoke("showNextBtn", 3.5f);
            }
            else 
            {
                Invoke("showNextBtn", 2.5f);
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
            monster.SetActive(true);
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
