using UnityEngine;
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
    private bool mousePressed;
    private Vector3 tempPosition;

    void Start() {
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



    void OnMouseDown()
    {
        dist = Camera.main.WorldToScreenPoint(transform.position);
        posX = Input.mousePosition.x - dist.x;
        posY = Input.mousePosition.y - dist.y;
        mousePressed = true;
    }

    void OnMouseDrag()
    {

        Vector3 curPos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, dist.z);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
        transform.position = worldPos;
    }

    void OnMouseUp()
    {
        if (mousePressed)
        {
            Debug.Log("mouse dragged");
            tempPosition = transform.position;
            tempPosition.x = (float)Math.Round(tempPosition.x / Constants.nodeSize) * Constants.nodeSize;
            tempPosition.z = (float)Math.Round(tempPosition.z / Constants.nodeSize) * Constants.nodeSize;
            Debug.Log(tempPosition);
            transform.position = tempPosition;
        }
        mousePressed = false;
    }
}
