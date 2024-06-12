using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManage : MonoBehaviour
{
    public Text storyText;
    private string fullText;
    public int checkTextNum = 1;
    public Button continueButton;
    [SerializeField]
    private float typingSpeed = 0.05f;
    [SerializeField]
    private Image introImage;
    [SerializeField]
    public Sprite[] introSprite;
    private Coroutine typingCoroutine;
    [SerializeField]
    private Image startImg;
    [SerializeField]
    private Button startButton;

    private string currentText = "";

    private void Awake()
    {
        introImage = GameObject.Find("IntroImg").GetComponent<Image>();
        storyText = GameObject.Find("IntroText").GetComponent<Text>();
        continueButton = GameObject.Find("Canvas").transform.Find("NextBtn").GetComponent<Button>();
        startImg = GameObject.Find("Canvas").transform.Find("StartImg").GetComponent<Image>();
        startButton = GameObject.Find("Canvas").transform.Find("StartBtn").GetComponent<Button>();

        checkIntroTxt(checkTextNum);
    }

    private void Start()
    {
        typingCoroutine = StartCoroutine(ShowText());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
                ShowFullText();
            }
        }
    }

    private void checkIntroTxt(int num)
    {
        switch (num)
        {
            case 1:
                fullText = "축하합네다";
                break;
            case 2:
                fullText = "10월 로동복권 추첨이 끝났습네다.\n동무의 이름이 뽑혔습네다.";
                break;
            case 3:
                fullText = "국가 검열성은 조선 국경 차단소에 즉각 인원 배치가 필요함을 보고받았습네다.";
                break;
            case 4:
                fullText = "동무의 가족들을 위해 차단소 근처에 살림집이 지급되었습네다. 8등급 연립주택입네다.";
                break;
            default:
                fullText = "위대한 수령 동지를 위하여.";
                break;
        }
    }

    IEnumerator ShowText()
    {
        continueButton.gameObject.SetActive(false);
        int check = 0;
        while (check < fullText.Length)
        {
            currentText = fullText.Substring(0, check + 1);
            storyText.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
            check++;
        }
        OnTypingComplete();
    }

    private void ShowFullText()
    {
        storyText.text = fullText;
        OnTypingComplete();
        typingCoroutine = null;
    }

    private void OnTypingComplete()
    {
        continueButton.gameObject.SetActive(true);
        checkTextNum++;
    }

    public void GoNext()
    {
        if (checkTextNum == 6)
        {
            introImage.gameObject.SetActive(false);
            storyText.gameObject.SetActive(false);
            continueButton.gameObject.SetActive(false);
            startButton.gameObject.SetActive(true);
            startImg.gameObject.SetActive(true);
        }
        else
        {
            checkIntroTxt(checkTextNum);
            typingCoroutine = StartCoroutine(ShowText());
            introImage.sprite = introSprite[checkTextNum - 1];
        }
    }

    public void GoGame()
    {
        SceneManager.LoadScene("Game");
    }
}
