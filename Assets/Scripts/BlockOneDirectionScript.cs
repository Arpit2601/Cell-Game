using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BlockOneDirectionScript : MonoBehaviour
{
    void Update()
    {
        for(int i=0;i<3;i++)
        {
            gameObject.GetComponent<CellMovement>().standardClamp[i]= Math.Abs((int)Math.Round(transform.forward[i]));
        }
    }
}
