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
                fullText = "�����ճ״�";
                break;
            case 2:
                fullText = "10�� �ε����� ��÷�� �������״�.\n������ �̸��� �������״�.";
                break;
            case 3:
                fullText = "���� �˿����� ���� ���� ���ܼҿ� �ﰢ �ο� ��ġ�� �ʿ����� ����޾ҽ��״�.";
                break;
            case 4:
                fullText = "������ �������� ���� ���ܼ� ��ó�� �츲���� ���޵Ǿ����״�. 8��� ���������Գ״�.";
                break;
            default:
                fullText = "������ ���� ������ ���Ͽ�.";
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
