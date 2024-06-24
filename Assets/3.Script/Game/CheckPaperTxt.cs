using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckPaperTxt : MonoBehaviour
{
    public string sortingLayerName = "Default";
    public int orderInLayer = 15;

    void Start()
    {
        // Get the Mesh Renderer component attached to the TextMeshPro object
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        // Set the sorting layer and order in layer
        meshRenderer.sortingLayerName = sortingLayerName;
        meshRenderer.sortingOrder = orderInLayer;
    }
}
