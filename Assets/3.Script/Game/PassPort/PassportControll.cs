using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassportControll : MonoBehaviour
{
    public bool checkEnd = false;
    public bool enterAllow = false;

    private SpriteRenderer spriteRenderer;

    public bool passportGet = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = 1;
    }

    public void resetPort()
    {
        destroyChild();
        checkEnd = false;
    }

    public void getPassPort()
    {
        spriteRenderer.sortingOrder = 7;
        gameObject.transform.position = new Vector3(-6.2f, -2f, 0f);
        passportGet = true;
    }

    public void setEnterAllowed()
    {
        enterAllow = true;
        checkEnd = true;
    }

    public void setEnterDenied()
    {
        enterAllow = false;
        checkEnd = true;
    }

    public void destroyChild()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
