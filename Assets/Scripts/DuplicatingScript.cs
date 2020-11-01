using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicatingScript : MonoBehaviour
{
    
    private TimeController timeController;

    public GameObject directionCellPrefab;
    public GameObject RotatingCellPrefab;
    public GameObject blockCellPrefab;
    public GameObject generatingCellPrefab;


    public Vector3 duplicateDir = new Vector3(0, 0, 0);
    private bool moving;

    void Start()
    {
        timeController = TimeController.instance;
        moving = false;
    }

    void Update()
    {
        if (timeController.running && !moving)
        {
            StartCoroutine(DuplicateCells());
        }
    }

    IEnumerator DuplicateCells()
    {
        if (!moving && timeController.running)
        {
            moving = true;
            
            yield return new WaitForSeconds(Constants.TimeStep);
            moving = false;
        }
    }
}
