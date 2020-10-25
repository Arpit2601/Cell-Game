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

    // void OnMouseDown()
    // {
    //     dist = Camera.main.WorldToScreenPoint(transform.position);
    //     posX = -Input.mousePosition.x + dist.x;
    //     posY = -Input.mousePosition.y + dist.y;
    //     posZ = -Input.mousePosition.y + dist.z;
    //     mousePressed = true;
    // }

    void OnMouseDrag()
    {

        // if(Camera.main.transform.eulerAngles == new Vector3(90,0,0))
        // {
        //     Debug.Log("camera pointing downwards.");
        //     Vector3 curPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist.z);
        //     Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos + new Vector3(posX, posY));
        //     worldPos.y = 2f;
        //     worldPos.x = Mathf.Clamp(worldPos.x, 0f, 40.5f);
        //     worldPos.z = Mathf.Clamp(worldPos.z, 0f, 40.5f);
        //     transform.position = worldPos;
        // }

        // else
        // {
        //     Debug.Log("camera rotated");
        //     Vector3 curPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.y);
        //     Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos + new Vector3(posX, posY, posZ));
        //     worldPos.y = 2f;
        //     worldPos.x = Mathf.Clamp(worldPos.x, 0f, 40.5f);
        //     worldPos.z = Mathf.Clamp(worldPos.z, 0f, 40.5f);
        //     transform.position = worldPos;
        // }

        Vector3? positionHighlightedNode = nodeController.positionHighlightedNode;
        if (positionHighlightedNode != null )
        {
            transform.position = (Vector3)(positionHighlightedNode + offset);
        }

    }

    // void OnMouseUp()
    // {
    //     if (mousePressed)
    //     {
    //         Debug.Log("mouse dragged");
    //         tempPosition = transform.position;
    //         tempPosition.x = (float)Math.Round(tempPosition.x / Constants.nodeSize) * Constants.nodeSize;
    //         tempPosition.z = (float)Math.Round(tempPosition.z / Constants.nodeSize) * Constants.nodeSize;

    //         Debug.Log(tempPosition);
    //         transform.position = tempPosition;
    //     }
    //     mousePressed = false;
    // }

}
