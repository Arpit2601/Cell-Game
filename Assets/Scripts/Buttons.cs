using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    private TimeController timeController ;
    void Start()
    {
        timeController = TimeController.instance;
    }

    public void StepPressed()
    {
        Debug.Log("Step Pressed");
		timeController.Step();
    }

    public void PlayPressed()
    {
        Debug.Log("Play Pressed");
		timeController.Play();
    }

}
