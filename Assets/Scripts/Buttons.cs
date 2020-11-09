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
        // Debug.Log("Step Pressed");
		timeController.Step();
    }

    public void PlayPressed()
    {
        // Debug.Log("Play Pressed");
		timeController.Play();
    }

    public void ResetPressed()
    {
        // Debug.Log("Reset Pressed");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        // Debug.Log("Reset Pressed");
		SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        // Debug.Log("Reset Pressed");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

}
