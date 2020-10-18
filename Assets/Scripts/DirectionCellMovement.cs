using UnityEngine;
using System.Collections; 
using System;
public class DirectionCellMovement : MonoBehaviour
{
    public Vector3 targetPosition ;
    private TimeController timeController;
    private bool moving;

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

}
