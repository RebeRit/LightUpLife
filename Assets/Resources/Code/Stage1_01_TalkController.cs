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
        // 스크립트 작성하는 곳
        names.Add("주인공");
        names.Add("????");
        names.Add("주인공");
        names.Add("????");
        names.Add("주인공");

        portraits.Add("Images/Hero_common");
        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Hero_common");
        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Hero_question");

        scripts.Add("램프에서 이렇게 약한 빛이 나올 줄이야... 빛의 정체는 이거였구나?");
        scripts.Add("거기 아무도 없어요? 나 좀 꺼내줘!");
        scripts.Add("랜턴에서 말소리가 나오는데...? 도대체 무슨 일이지?");
        scripts.Add("내가 잠깐 힘을 줄게! 근처의 몬스터가 가져간 열쇠를 찾아서 날 꺼내줘!");
        scripts.Add("아니... 갑자기 그러면 이해가 안되잖아...!");

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
            /* 플레이어가 아네모네가 갇혀있는 램프에 닿으면 스크립트가 재생된다
            -> 지하실의 수상한 빛의 정체는 바로 너였구나!
            -> (아네모네) 어서 날 꺼내줘! 갑자기 몬스터의 공격을 받아 빛이 사라졌다. 아네모네는 몬스터의 기척을 느끼는 특성이 있음
            -> 지하실에 몬스터 한 마리가 있는데 그 몬스터를 잡아달라는 이야기 . 그리고 마우스 클릭하면 총 나가게 코드 다시짜기
            총알은 지하실에 있는 몬스터에 접근하면 발사가 가능하게 코딩 */
            Debug.Log("아네모네를 찾아 스크립트가 진행됩니다.");

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
