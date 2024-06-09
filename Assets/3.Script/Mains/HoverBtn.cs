using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class HoverBtn : MonoBehaviour, IPointerExitHandler, IPointerClickHandler
{
    public GameObject startPanel;

    public void OnPointerExit(PointerEventData eventData)
    {
        if (startPanel != null)
        {
            gameObject.SetActive(false);
            startPanel.SetActive(true);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("GameScene");
    }
}
