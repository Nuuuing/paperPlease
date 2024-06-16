using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoothSpeak : MonoBehaviour
{
    public Sprite originalSprite; // The original sprite

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool isSpeak = false;
    public bool isOver = false;

    GameManager gm;
    TimeCheck time;

    private void Awake()
    {
        GameObject.FindObjectOfType<GameManager>().TryGetComponent(out gm);
        GameObject.FindObjectOfType<TimeCheck>().TryGetComponent(out time);

        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOver && Input.GetMouseButtonDown(0))
        {
            gm.portChecked = false;
            time.startTimer();
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
