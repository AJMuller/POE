using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

    // Use this for initialization
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
		
	}

    void Resume()
    {
        pauseMenuUI.SetActive(false);
       
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        
        gameIsPaused = true;
    }
}
