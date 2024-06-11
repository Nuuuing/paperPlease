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
            fullText = "축하합니다.\n당신이 고대하던 검문소에 취업하게 되었습니다.";
        }
        else if(num == 2)
        {
            fullText = "집사님.\n고양이들이 애타게 당신을 기다립니다.";
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
