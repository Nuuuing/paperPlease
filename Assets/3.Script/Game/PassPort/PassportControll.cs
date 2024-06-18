using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassportControll : MonoBehaviour
{
    public bool checkEnd = false;
    private bool enterAllow = false;

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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
