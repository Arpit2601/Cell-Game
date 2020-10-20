﻿using UnityEngine;
using System.Collections; 
using System;
public class DirectionCellMovement : MonoBehaviour
{
    public Vector3 targetPosition ;
    private TimeController timeController;
    private bool moving;

    // For dragging object
    private Vector3 dist;
    private float posX;
    private float posY;
    private float posZ;
    private bool mousePressed;
    private Vector3 tempPosition;

    private Vector3 initialPosition;

    void Start() {
        initialPosition = transform.position;  // initial position of our cell
        targetPosition = transform.position;  
        timeController = TimeController.instance;
        moving  =false;
    }

    void Update()
    {
        if(timeController.running && !moving){
                GetNextWaypoint();
                StartCoroutine(MoveFromTo(transform.position,targetPosition,Constants.TimeStep));
        }
    }

     IEnumerator MoveFromTo(Vector3 pointA, Vector3 pointB, float time){
        if (!moving && timeController.running){ 
            moving = true;
            float t = 0f;
            while (t < 1f && timeController.running){
                t += Time.deltaTime / time;
                transform.position = Vector3.Lerp(pointA, pointB, t); 
                yield return 0; 
        }
        moving = false;
     }
 }

    void GetNextWaypoint()
	{
        targetPosition = transform.position;
        targetPosition.x = (float)Math.Round(targetPosition.x/Constants.nodeSize);
        targetPosition.z = (float)Math.Round(targetPosition.z/Constants.nodeSize);
        targetPosition += transform.forward;
        targetPosition.x *= Constants.nodeSize;
        targetPosition.z *= Constants.nodeSize;
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

        Vector3? positionHighlightedNode = Node.positionHighlightedNode;
        if(positionHighlightedNode != null){
            transform.position = (Vector3) (initialPosition + positionHighlightedNode);
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