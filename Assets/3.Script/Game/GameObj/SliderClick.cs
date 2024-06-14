using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderClick : MonoBehaviour
{
    [SerializeField]
    private Sprite upSlider;

    [SerializeField]
    private Sprite downSlider;

    public bool isSliderUp = false;
    private bool isOver = false;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isOver && Input.GetMouseButtonDown(0))
        {
            onClickSlider();
        }
    }

    public void onClickSlider()
    {
        if (isSliderUp)
        {
            spriteRenderer.sprite = downSlider;
            isSliderUp = false;
        }
        else
        {
            spriteRenderer.sprite = upSlider;
            isSliderUp = true;
        }
    }

    void OnMouseOver()
    {
        isOver = true;
    }

    void OnMouseExit()
    {
        isOver = false;
    }
}
