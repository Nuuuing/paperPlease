using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject panelHover;

    void Start()
    {
        if (panelHover != null)
        {
            panelHover.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (panelHover != null)
        {
            gameObject.SetActive(false);
            panelHover.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (panelHover != null)
        {
            gameObject.SetActive(true);
            panelHover.SetActive(false);
        }
    }

}
