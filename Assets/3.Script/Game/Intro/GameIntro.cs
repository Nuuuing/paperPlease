using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameIntro : MonoBehaviour
{
    private Image introImage;
    [SerializeField]
    public Sprite[] introSprite;
    public Button startButton;
    private int checkNum = 1;

    private void Awake()
    {
        introImage = GameObject.Find("NewsPaper").GetComponent<Image>();
        startButton = GameObject.Find("StartBtn").GetComponent<Button>();
    }

    private void Start()
    {
        introImage.sprite = introSprite[checkNum - 1];
    }

    public void startGame()
    {
        SceneManager.LoadScene("Game");
    }
}
