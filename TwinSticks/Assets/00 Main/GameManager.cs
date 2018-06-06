using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool recording = true;

    private bool isPaused = false;
    private float initialFixedDelta;


	// Use this for initialization
	void Start () {
        initialFixedDelta = Time.fixedDeltaTime;

	}

    // Update is called once per frame
    void Update ()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            recording = false;
        }
        else
        {
            recording = true;
        }

        if (Input.GetKeyDown(KeyCode.P) && isPaused)
        {
            isPaused = false;
            ResumeGame();
        } else if (Input.GetKeyDown(KeyCode.P) && !isPaused)
        {
            isPaused = true;
            PauseGame();
        }

        // TODO Add if Statement  - if is Paused has changed state in the last frame - if(resumeGame...)

    }

    void PauseGame ()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }

    void ResumeGame ()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = initialFixedDelta;
    }

    private void OnApplicationPause (bool pause)
    {
        isPaused = pause;
    }
}
