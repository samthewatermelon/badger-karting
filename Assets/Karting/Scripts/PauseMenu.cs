using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class PauseMenu : NetworkBehaviour
{
    void Update()
    {
        // Check if the script is running on the server or the client
        if (isServer)
        {
            // Check if the Esc key is pressed
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Toggle the pause state on the server
                TogglePause();
            }
        }
        else if (isLocalPlayer)
        {
            // Check if the Esc key is pressed
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Send a message to the server to toggle the pause state
                CmdTogglePause();
            }
        }
    }

    // Command method that can be invoked on the server
    [Command]
    void CmdTogglePause()
    {
        TogglePause();
    }

    void TogglePause()
    {
        // Check if the game is paused
        if (Time.timeScale > 0)
        {
            // Pause the game
            Time.timeScale = 0;
            Debug.Log("Game Pause");
        }
        else
        {
            // Resume the game
            Time.timeScale = 1;
            Debug.Log("Game Resumes");
        }
    }
}


