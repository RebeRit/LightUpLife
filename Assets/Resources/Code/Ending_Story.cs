using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Ending_Story : MonoBehaviour
{
    public Text scriptObj;
    List<string> scripts = new List<string>();
    List<string> images = new List<string>();
    int checkScriptLine;
    public GameObject nextStoryBtn;
    public GameObject backgroundImg;
    public Image background;
    public Button nextBtn;

    // Start is called before the first frame update
    void Start()
    {
        background = backgroundImg.GetComponent<Image>();

        scripts.Add("���� ��� �Ǵ��� ����ġ��, ������ �ٽ� ������ ���� ä�������ϴ�.");
        scripts.Add("�׸��� ���ΰ��� �ձ� ����鿡�� ȯȣ�� �޾ҽ��ϴ�.");
        scripts.Add("���ο� ������ ź���̾���.");
        scripts.Add("�׷��� �����,");
        scripts.Add("ġŲ");
        scripts.Add("�԰�");
        scripts.Add("����");
        scripts.Add("��");

        images.Add("Images/Story_0_02_Background");
        images.Add("Images/the_hero");
        images.Add("Images/the_hero");
        images.Add("Images/Story_0_06_Background");
        images.Add("Images/Story_0_06_Background");
        images.Add("Images/Story_0_06_Background");
        images.Add("Images/Story_0_06_Background");
        images.Add("Images/Story_0_06_Background");

        nextBtn.onClick.AddListener(nextScript);

        checkScriptLine = 0;
        scriptObj.text = "";
        StartCoroutine(Typing(scripts[checkScriptLine]));
        background.GetComponent<Image>().sprite = Resources.Load<Sprite>(images[checkScriptLine].ToString());
        nextStoryBtn.SetActive(false);
        Invoke("showNextBtn", 4.0f);
    }

    void nextScript()
    {
        if (checkScriptLine < 7)
        {
            ++checkScriptLine;
            scriptObj.text = "";
            StartCoroutine(Typing(scripts[checkScriptLine]));
            background.GetComponent<Image>().sprite = Resources.Load<Sprite>(images[checkScriptLine].ToString());
            Debug.Log("Show Next Script");
            nextStoryBtn.SetActive(false);
            Invoke("showNextBtn", 4.0f);
        }
        else
        {
            SceneManager.LoadScene("1_MainMenu");
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
