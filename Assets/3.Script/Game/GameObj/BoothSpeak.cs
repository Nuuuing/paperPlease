using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoothSpeak : MonoBehaviour
{
    public Sprite originalSprite; 
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public bool isSpeak;
    public bool isOver;

    private GameManager gm;
    private TimeCheck time;

    private void Awake()
    {
        GameObject.FindObjectOfType<GameManager>().TryGetComponent(out gm);
        GameObject.FindObjectOfType<TimeCheck>().TryGetComponent(out time);

        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        isSpeak = false;
        isOver = false;
    }

    void Update()
    {
        if (isSpeak && isOver && Input.GetMouseButtonDown(0))
        {
            time.startTimer();
            StopAnimation();
        }
    }

    public void PlayAnimation()
    {
        if (!isSpeak)
        {
            animator.SetBool("isSpeak", true);
            isSpeak = true;
        }
    }

    public void StopAnimation()
    {
        if (isSpeak)
        {
            animator.SetBool("isSpeak", false);
            spriteRenderer.sprite = originalSprite;
            isSpeak = false;
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
