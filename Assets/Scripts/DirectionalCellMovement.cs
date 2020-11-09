using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DirectionalCellMovement : MonoBehaviour
{
    private void Start() {
        for(int i=0;i<3;i++)
        {
            gameObject.GetComponent<CellMovement>().standardDir[i]= (int)Math.Round(transform.forward[i]);
        }
    }

    void Update()
    {
        for(int i=0;i<3;i++)
        {
            gameObject.GetComponent<CellMovement>().standardDir[i]= (int)Math.Round(transform.forward[i]);
        }
    }
}
