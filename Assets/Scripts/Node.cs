using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private NodeController nodeController;

    private Renderer rend;
    private Color startColor;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        nodeController = NodeController.instance;
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
        nodeController.positionHighlightedNode = transform.position;
    }


    void OnMouseExit()
    {
        rend.material.color = startColor;
        nodeController.positionHighlightedNode = null;
    }


}
