using UnityEngine;
using System.Collections; 
using System;
public class DirectionCellMovement : MonoBehaviour
{
    private Vector3 targetPosition ;
    private Vector3 dir ;
    void Start() {
        targetPosition = transform.position;  
        //  GetNextWaypoint();
    }

    void Update()
    {
       	if (Vector3.Distance(transform.position, targetPosition) > Constants.distanceDelta)
        {
            Vector3 dir = targetPosition - transform.position;
            transform.Translate(dir.normalized * Constants.nodeSize * Time.deltaTime / Constants.TimeStep, Space.World);
        }else{
           GetNextWaypoint();
           Debug.Log(transform.forward);
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
