using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailText : MonoBehaviour
{
    public int sortingOrder = 7;

    MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        orderChange();
    }

    private void orderChange()
    {
        meshRenderer.sortingOrder = sortingOrder;
    }
}
