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
    private PersonIntrControll personP;
    private PersonSpawner personSpawner;
    private PassportControll passport;

    private void Awake()
    {
        GameObject.FindObjectOfType<GameManager>().TryGetComponent(out gm);
        GameObject.FindObjectOfType<TimeCheck>().TryGetComponent(out time);
        GameObject.FindObjectOfType<PersonIntrControll>().TryGetComponent(out personP);
        GameObject.FindObjectOfType<PersonSpawner>().TryGetComponent(out personSpawner);
        GameObject.FindObjectOfType<PassportControll>().TryGetComponent(out passport);

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
            personP.changePerson();

            GameObject firstInactivePerson = personSpawner.GetFirstInactivePerson();

            if (firstInactivePerson != null)
            {
                firstInactivePerson.SetActive(true);
                var personSituControll = firstInactivePerson.GetComponent<PersonSituControll>();
                if (personSituControll != null)
                {
                    personSituControll.Initialize();
                    personSituControll.SetGoWay(1); // Set to move to booth
                }
            }
        }
    }

    public void PlayAnimation()
    {
        if (!isSpeak)
        {
            animator.SetBool("isSpeak", true);
            isSpeak = true;
            personP.resetPerson();
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
