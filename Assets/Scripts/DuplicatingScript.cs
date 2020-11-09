using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class DuplicatingScript : MonoBehaviour
{
    
    private TimeController timeController;

    public GameObject directionCellPrefab;
    public GameObject RotatingCellPrefab;
    public GameObject blockCellPrefab;
    public GameObject generatingCellPrefab;
    public GameObject OneDirCellPrefab;
    public GameObject BoundryPrefab;

    private List<GameObject> prefabs;
    public Vector3 duplicateDir = new Vector3(0, 0, 0);
    public Quaternion targetRot ;
    private bool moving;
    private Vector3 targetPosition;


    void Start()
    {
        prefabs = new List<GameObject>();
        prefabs.Add(directionCellPrefab);
        prefabs.Add(RotatingCellPrefab);
        prefabs.Add(blockCellPrefab);
        prefabs.Add(generatingCellPrefab);
        prefabs.Add(OneDirCellPrefab);
        prefabs.Add(BoundryPrefab);
        timeController = TimeController.instance;
        moving = false;
    }

    void Update()
    {
        if (timeController.running && !moving)
        {
            for(int i=0;i<3;i++)
            {
                duplicateDir[i] = (int)Math.Round(-1*transform.forward[i]);
            }
            GetCurrentTarget();
            StartCoroutine(DuplicateCells());
        }
    }

    IEnumerator DuplicateCells()
    {
        if (!moving && timeController.running)
        {
            moving = true;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, duplicateDir, out hit, Constants.nodeSize))
            {
                if(hit.collider.tag == "Player Cell"){
                    String prefabName = hit.collider.gameObject.name;
                    foreach (GameObject prefab in prefabs)
                    {
                        if(prefabName.Contains(prefab.name))
                        {
                           Instantiate(prefab, targetPosition , hit.collider.transform.rotation); 
                        }
                    }
                }
            }
            yield return new WaitForSeconds(Constants.TimeStep);
            moving = false;
        }
    }

    void GetCurrentTarget()
    {
        targetPosition = transform.position;
        targetPosition.x = (float)Math.Round(targetPosition.x / Constants.nodeSize);
        targetPosition.z = (float)Math.Round(targetPosition.z / Constants.nodeSize);
        targetPosition += -1*duplicateDir;
        targetPosition.x *= Constants.nodeSize;
        targetPosition.z *= Constants.nodeSize;
    }
}
