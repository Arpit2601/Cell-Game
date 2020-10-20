using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{


    public static Vector3? positionHighlightedNode;
	public Color hoverColor;


	private Renderer rend;
	private Color startColor;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

	void OnMouseEnter ()
	{
        rend.material.color = hoverColor;
        positionHighlightedNode = transform.position;
        Debug.Log(positionHighlightedNode);
	}


	void OnMouseExit ()
	{
		rend.material.color = startColor;
        positionHighlightedNode = null;
    }


}
