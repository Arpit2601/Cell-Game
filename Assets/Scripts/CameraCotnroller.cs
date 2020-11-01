using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCotnroller : MonoBehaviour
{
    // Start is called before the first frame update

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float scrollSpeed = 5f;

    public float minY = 10f;
    public float maxY = 80f;

    public float minX = 15f;
    public float maxX = 50f;

    public float minZ = 0f;
    public float maxZ = 40f;


    // Update is called once per frame
    void Update()
    {
        if(GameController.gameEnded)
        return;
        if (Input.GetKey("w"))  // move forward 
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s"))  // move backward
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d"))  // move right
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a"))  // move left
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);

        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        transform.position = pos;

    }
}
