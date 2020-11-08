using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{

    private NodeController nodeController;
    public Vector3 offset = new Vector3(0, 2, 0);

    private void Start()
    {
        nodeController = NodeController.instance;
    }
    void OnMouseDrag()
    {
        if(GameController.gameEnded || GameController.gameStarted)
        return;
        Vector3? positionHighlightedNode = nodeController.positionHighlightedNode;
        if (positionHighlightedNode != null )
        {
            transform.position = (Vector3)(positionHighlightedNode + offset);
        }

    }

}
