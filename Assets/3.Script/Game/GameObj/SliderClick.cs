using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderClick : MonoBehaviour
{
    [SerializeField]
    private Sprite upSlider;

    [SerializeField]
    private Sprite downSlider;

    [SerializeField]
    private GameObject shutter;

    public bool isSliderUp = false;
    private bool isOver = false;
    private bool isAnimating = false;

    private SpriteRenderer spriteRenderer;
    private PersonControll person;
    private Animator shutterAni;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        shutterAni = shutter.transform.GetComponent<Animator>();
        GameObject.FindObjectOfType<PersonControll>().TryGetComponent(out person);
    }

    private void Start()
    {
        isSliderUp = false;
        shutterAni.SetTrigger("SlideDown");
        isAnimating = false;
        spriteRenderer.sprite = downSlider;
        shutterAni.ResetTrigger("SlideUp");
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
        if (shutterAni == null) return;
        
        isAnimating = true;

        if (isSliderUp)
        {
            isSliderUp = false;
            shutterAni.SetTrigger("SlideDown");
            isAnimating = false;
            spriteRenderer.sprite = downSlider;
            shutterAni.ResetTrigger("SlideUp");
            //TODO: �ð� �� �ֱ�
            person.colorToDark();
        }
        else
        {
            isSliderUp = true;
            shutterAni.SetTrigger("SlideUp");
            spriteRenderer.sprite = upSlider;
            shutterAni.ResetTrigger("SlideDown");
            isAnimating = false;
            if(person.centeredPerson)
            {
                person.resetSprite();
            }
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
