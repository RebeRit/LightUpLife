using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;

public class Stage1_00_TalkController : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        portraitImg = characterImg.GetComponent<Image>();
        // ��ũ��Ʈ �ۼ��ϴ� ��
        names.Add("�����̼�");
        names.Add("���ΰ�");
        names.Add("�����̼�");
        names.Add("���ΰ�");
        names.Add("�ֹε�");
        names.Add("���ΰ�");

        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Hero_common");
        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Hero_help");
        portraits.Add("Images/Citizen_surprise");
        portraits.Add("Images/Hero_question");

        scripts.Add("���� �ұ� �Ϸ� ��, ���ΰ��� ��� ������ �Խ��ǿ��� ������ �پ����ϴ�.");
        scripts.Add("�ƴ�... ���� ��ȣ�� ���� �پ��ٴ�... �̰� ����...");
        scripts.Add("�Ϸ簡 ������, ���ΰ��� ������ ����� ���� ���� ����ϰ� �Ǿ����ϴ�.");
        scripts.Add("�̷� ����... �������ص� ��Ҵµ�, ������ ����̾���?");
        scripts.Add("���� ��! ���⿡�� ���� ������� �־�!");
        scripts.Add("��... ���! ���? ���� �츮 �� ���Ͻ� �Ա��ε�...");


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
            ++checkScriptLine;
            scriptObj.text = "";
            StartCoroutine(Typing(scripts[checkScriptLine]));
            nameObj.text = names[checkScriptLine];
            portraitImg.GetComponent<Image>().sprite = Resources.Load<Sprite>(portraits[checkScriptLine]);

            Debug.Log("Show Next Script");
            nextStoryBtn.SetActive(false);
            Invoke("showNextBtn", 2.5f);
        }
        else
        {
            backgroundImg.SetActive(false);
            characterImg.SetActive(false);
            nameObj.gameObject.SetActive(false);
            scriptObj.gameObject.SetActive(false);
            nextStoryBtn.SetActive(false);
            PlayerController.is_script_time = false;
        }
    }

    void showNextBtn()
    {
        nextStoryBtn.SetActive(true);
    }

    IEnumerator Typing(string text)
    {
        foreach(char letter in text.ToCharArray())
        {
            scriptObj.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
