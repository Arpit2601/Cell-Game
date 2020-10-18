using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static TimeController instance;

    public bool running;

    public bool inStep;
    public bool inPlay;
    
    void Awake ()
	{
		if (instance != null)
		{
			Debug.LogError("More than one TimeController in scene!");
			return;
		}
		instance = this;
	}
    void Start() {
        inPlay=false;
        inStep= false;
        running = false;
    }

    public void Step(){
        if(inPlay)
        {
            inPlay=false;
        }
        else if(!inStep)
        {
            inStep = true;
            StartCoroutine(takeStep());
        }
    }

    IEnumerator takeStep ()
	{
		running=true;
		yield return new WaitForSeconds(Constants.TimeStep);
        running = false;
        inStep = false;
	}

    public void Play(){
        inPlay = true;
        StartCoroutine(PlayStep());
    }

    IEnumerator PlayStep ()
	{
        while(inStep)
        {
            yield return 0;
        }
        while(inPlay && !inStep){
            running=true;
            yield return new WaitForSeconds(Constants.TimeStep);
            running = false;
        }
        inPlay=false;
	}


}
