using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color unSelectableColor;
    private NodeController nodeController;

    private Renderer rend;
    private Color startColor;

    public bool selectable =true;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        if(selectable)
        startColor = rend.material.color;
        nodeController = NodeController.instance;
        if(!selectable)
        {
            rend.material.color = unSelectableColor;
        }
    }

    void OnMouseEnter()
    {
        if(GameController.gameEnded || GameController.gameStarted||!selectable)
        return;
        rend.material.color = hoverColor;
        nodeController.positionHighlightedNode = transform.position;
    }


    void OnMouseExit()
    {
        if(!selectable)
        {
            return;
        }
        rend.material.color = startColor;
        nodeController.positionHighlightedNode = null;
    }


}
