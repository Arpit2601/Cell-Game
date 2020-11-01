using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void ResetPressed()
    {
        Debug.Log("Play Pressed");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
