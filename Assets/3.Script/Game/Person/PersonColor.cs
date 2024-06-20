using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

        colorToDark();
    }

    public void colorToDark()
    {
        spriteRenderer.color = new Color(41f / 255f, 32f / 255f, 22f / 255f, 1f);
    }

    public void resetSprite()
    {
        spriteRenderer.color = originalColor;
    }
}
