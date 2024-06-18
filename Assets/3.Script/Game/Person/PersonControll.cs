using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonControll : MonoBehaviour
{
    private bool isCheckEnd = false;
    public bool isMoveEnd = true;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    public bool centeredPerson = false;
    private SliderClick slider;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        centeredPerson = false;
        GameObject.FindObjectOfType<SliderClick>().TryGetComponent(out slider);   
    }

    private void Start()
    {
        colorToDark();
    }

    public void colorToDark()
    {
        spriteRenderer.color = new Color(41f / 255f, 32f / 255f, 22f / 255f, 1f);
    }

    public void appearPerson()
    {
        StartCoroutine(MoveToFront());
    }

    public void resetSprite()
    {
        spriteRenderer.color = originalColor;
    }

    private IEnumerator MoveToFront()
    {
        while (gameObject.transform.position.x < -6.2f)
        {
            Vector3 personPosition = gameObject.transform.position;
            personPosition.x += 1f * 0.015f;
            gameObject.transform.position = personPosition;

            yield return new WaitForSeconds(8f);
        }
        centeredPerson = true;
    }
}
