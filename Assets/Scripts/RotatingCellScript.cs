using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCellScript : MonoBehaviour
{
    private TimeController timeController;
    public Vector3 rotateDir = new Vector3(0, 0, 0);
    private bool moving;

    private Vector3[] directions = new[] { new Vector3(1, 0, 0), new Vector3(0, 0, 1), new Vector3(0, 0, -1), new Vector3(-1, 0, 0) };

    void Start()
    {
        timeController = TimeController.instance;
        moving = false;
    }

    void Update()
    {
        if (timeController.running && !moving)
        {
            StartCoroutine(RotateCells());
        }
    }

    IEnumerator RotateCells()
    {
        if (!moving && timeController.running)
        {
            moving = true;
            for (int i = 0; i < 4; i++)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, directions[i], out hit, Constants.nodeSize))
                {
                    hit.collider.GetComponent<CellMovement>().rotateCell(rotateDir);
                }
            }
            yield return new WaitForSeconds(Constants.TimeStep);
            moving = false;
        }
    }

}
