using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    public static NodeController instance;
    public Vector3? positionHighlightedNode;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one NodeController in scene!");
            return;
        }
        instance = this;
        positionHighlightedNode = null;
    }

}
