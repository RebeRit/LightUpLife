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
    public GameObject Click_sound;

    // Start is called before the first frame update
    void Start()
    {
        background = backgroundImg.GetComponent<Image>();

        scripts.Add("�׷��� ���ΰ��� ���ฦ ����ġ�µ� �����ϰ�,");
        scripts.Add("�� ������ �ƹ��� �����ٴ� �� �ٽ� ��� ������ �����߽��ϴ�.");
        scripts.Add("�Ƴ׸�״� ���縦 ���ϸ� �ٸ� �ձ����� ���캸�� ���ڴٸ� �������ϴ�.");
        scripts.Add("�ð��� ������...");
        scripts.Add("���ٸ� �ձ����� ��ư��� ��� ��, �� �ҳడ ���ΰ��� ã�ƿԽ��ϴ�.");
        scripts.Add("\"����...\"");
        scripts.Add("���ΰ��� ���� ��� ���� ���� ���߽��ϴ�.");
        scripts.Add("���� �� ���ڿ��� �ô� �� �ҳడ ���ΰ��� �� �տ� ���־��� �����Դϴ�.");
        scripts.Add("\"����� �ƹ����� ���� �̷��ּ̱���...\"");
        scripts.Add("\"�츮 ����, �ƴ� �� ���� ��� ����� ���� �ٽ� ��� ����� �ּż� �����ؿ�.\"");
        scripts.Add("[ LIGHT UP LIFE ]");

        images.Add("Images/the_hero");
        images.Add("Images/Story_0_02_Background");
        images.Add("Images/yojeong");
        images.Add("Images/Story_0_06_Background");
        images.Add("Images/girl");
        images.Add("Images/girl");
        images.Add("Images/girl");
        images.Add("Images/girl");
        images.Add("Images/girl");
        images.Add("Images/girl");
        images.Add("Images/Ending");

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
        if (checkScriptLine < 10)
        {
            Click_sound.GetComponent<AudioSource>().Play();
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
            Click_sound.GetComponent<AudioSource>().Play();
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
