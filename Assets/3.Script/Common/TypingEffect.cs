using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TypingEffect : MonoBehaviour
{
    public Text storyText;
    private string fullText;
    [SerializeField]
    private int checkTextNum;

    public Button continueButton;
    public float typingSpeed = 0.05f;

    private string currentText = "";

    private void OnEnable()
    {
        storyText = GetComponentInChildren<Text>();
        Transform parent = transform.parent;
        while (parent != null && continueButton == null)
        {
            continueButton = parent.GetComponentInChildren<Button>(true); // true to include inactive objects
            parent = parent.parent;
        }
        checkIntroTxt(checkTextNum);
    }
    void Start()
    {
        StartCoroutine(ShowText());
    }

    private void checkIntroTxt(int num)
    {
        if( num == 1)
        {
            fullText = "�����մϴ�.\n����� ����ϴ� �˹��ҿ� ����ϰ� �Ǿ����ϴ�.";
        }
        else if(num == 2)
        {
            fullText = "�����.\n����̵��� ��Ÿ�� ����� ��ٸ��ϴ�.";
        }
        else
        {
            fullText = "";
        }

    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            storyText.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }

        OnTypingComplete();
    }

    private void OnTypingComplete()
    {
        continueButton.gameObject.SetActive(true);
        checkTextNum = 2;
    }

    private void OnNextButtonClick()
    {
        if(checkTextNum == 1)
        {
            checkTextNum = 2;
            checkIntroTxt(checkTextNum);
            StartCoroutine(ShowText());
        }
        else if (checkTextNum ==2)
        {
            checkTextNum = 3;
            checkIntroTxt(checkTextNum);
            StartCoroutine(ShowText());
        }
        else
        {
            SceneManager.LoadScene("Game");
        }
    }
}
