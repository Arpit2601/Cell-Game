﻿using UnityEngine;
using System.Collections;
using System;
public class CellMovement : MonoBehaviour
{
    private Vector3 targetDir;
    private Vector3 lastPos;
    private Vector3 targetPosition;
    public Vector3 standardDir;
    private TimeController timeController;
    private bool moving;
    private bool rotating;
    private Quaternion targetRotation;
    private Quaternion lastRotation;


    void Start()
    {
        targetPosition = transform.position;
        timeController = TimeController.instance;
        moving = false;
        rotating = false;
        lastRotation = transform.rotation;
        targetRotation = transform.rotation;
    }

    void Update()
    {
        if (timeController.running && !moving)
        {
            lastPos = transform.position;
            targetDir = standardDir;
            StartCoroutine(TranslateCell());
        }
    }

    IEnumerator TranslateCell()
    {
        if (!moving && timeController.running)
        {
            moving = true;
            float t = 0f;
            while (t < 1f && timeController.running)
            {
                GetCurrentWaypoint();
                Collider[] colliders = Physics.OverlapSphere(transform.position, Constants.nodeSize);
                foreach (Collider collider in colliders)
                {
                    if (collider.tag == "Player Cell")
                    {
                        int col = collider.GetComponent<CellMovement>().checkCollision(targetPosition,targetDir);
                        if (col==1)
                        {
                            if(targetDir[0]!=0){
                                collider.GetComponent<CellMovement>().ModifyDirection(new Vector3(targetDir[0],0,0));
                            }
                            else
                            {
                                collider.GetComponent<CellMovement>().ModifyDirection(targetDir);
                            }
                           
                        }
                        if(col == 2)
                        {
                            targetPosition = lastPos;
                            targetDir =  new Vector3 (0,0,0);
                        }
                    }
                }
                t += Time.deltaTime / Constants.TimeStep;
                transform.position = Vector3.Lerp(lastPos, targetPosition, t);
                yield return 0;
            }
            moving = false;
        }
    }
    void GetCurrentWaypoint()
    {
        targetPosition = lastPos;
        targetPosition.x = (float)Math.Round(targetPosition.x / Constants.nodeSize);
        targetPosition.z = (float)Math.Round(targetPosition.z / Constants.nodeSize);
        targetPosition += targetDir;
        targetPosition.x *= Constants.nodeSize;
        targetPosition.z *= Constants.nodeSize;
    }

    void ModifyDirection(Vector3 dir)
    {
        for (int i = 0; i < 3; i++)
        {
            targetDir[i] = Math.Max(-1, Math.Min(targetDir[i] + dir[i], 1));
        }
    }

    int checkCollision(Vector3 targetPos,Vector3 targetD)
    {
        GetCurrentWaypoint();

        if( targetPos == targetPosition)
        {
            // Check if moveable 
            return 1;
        }
        if(targetD == -1*targetDir && targetPos == lastPos)
        {
            targetDir = new Vector3 (0,0,0);
            return 2;
        }
        return 0;
    }

    public void rotateCell(Vector3 angle)
    {
        targetRotation = Quaternion.Euler(targetRotation.eulerAngles + angle);
        if(!rotating){
            StartCoroutine(RotateMe());
        }
    }

    IEnumerator RotateMe()
    {
        rotating = true;
        float t = 0f;
        lastRotation = transform.rotation;
        while (t < 1f && timeController.running)
        {
            t += (Time.deltaTime / Constants.TimeStep)*1.1f;
            transform.rotation = Quaternion.Slerp(lastRotation, targetRotation, t);
            yield return 0;
        }
        rotating = false;
        
    }


}