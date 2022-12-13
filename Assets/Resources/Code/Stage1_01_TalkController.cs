using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;

public class Stage1_01_TalkController : MonoBehaviour
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
        names.Add("���ΰ�");
        names.Add("????");
        names.Add("���ΰ�");
        names.Add("????");
        names.Add("���ΰ�");

        portraits.Add("Images/Hero_common");
        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Hero_common");
        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Hero_question");

        scripts.Add("�������� �̷��� ���� ���� ���� ���̾�... ���� ��ü�� �̰ſ�����?");
        scripts.Add("�ű� �ƹ��� �����? �� �� ������!");
        scripts.Add("���Ͽ��� ���Ҹ��� �����µ�...? ����ü ���� ������?");
        scripts.Add("���� ��� ���� �ٰ�! ��ó�� ���Ͱ� ������ ���踦 ã�Ƽ� �� ������!");
        scripts.Add("�ƴ�... ���ڱ� �׷��� ���ذ� �ȵ��ݾ�...!");

    }

    // Update is called once per frame
    void nextScript()
    {
        if (checkScriptLine < 4)
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
        foreach (char letter in text.ToCharArray())
        {
            scriptObj.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            /* �÷��̾ �Ƴ׸�װ� �����ִ� ������ ������ ��ũ��Ʈ�� ����ȴ�
            -> ���Ͻ��� ������ ���� ��ü�� �ٷ� �ʿ�����!
            -> (�Ƴ׸��) � �� ������! ���ڱ� ������ ������ �޾� ���� �������. �Ƴ׸�״� ������ ��ô�� ������ Ư���� ����
            -> ���Ͻǿ� ���� �� ������ �ִµ� �� ���͸� ��ƴ޶�� �̾߱� . �׸��� ���콺 Ŭ���ϸ� �� ������ �ڵ� �ٽ�¥��
            �Ѿ��� ���Ͻǿ� �ִ� ���Ϳ� �����ϸ� �߻簡 �����ϰ� �ڵ� */
            Debug.Log("�Ƴ׸�׸� ã�� ��ũ��Ʈ�� ����˴ϴ�.");

            nextBtn.onClick.AddListener(nextScript);

            backgroundImg.SetActive(true);
            characterImg.SetActive(true);
            nameObj.gameObject.SetActive(true);
            scriptObj.gameObject.SetActive(true);
            nextStoryBtn.SetActive(true);
            PlayerController.is_script_time = true;

            checkScriptLine = 0;
            scriptObj.text = "";
            StartCoroutine(Typing(scripts[checkScriptLine]));
            nameObj.text = names[checkScriptLine];
            portraitImg.GetComponent<Image>().sprite = Resources.Load<Sprite>(portraits[checkScriptLine].ToString());
            nextStoryBtn.SetActive(false);
            Invoke("showNextBtn", 2.5f);
        }
    }

}
