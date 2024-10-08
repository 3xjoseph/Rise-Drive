using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] Canvas pauseGame;

    bool isEnabled = false;

    void Start() 
    {
        pauseGame.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isEnabled == false)
            {
                pauseGame.enabled = true;
                
                Time.timeScale = 0;
                isEnabled = true;
            }
            else
            {
                pauseGame.enabled = false;
                
                Time.timeScale = 1;
                isEnabled = false;
            }
            
        }
    }
}
