using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Button : MonoBehaviour
{
    //Restarts the current scene by resetting the time scale to normal
    public void Restart() 
    {
        // Reset time scale to normal speed
        Time.timeScale = 1.0f;

        // Load the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Exits the game
    public void ExitGame() 
    {
        // Exit the game application
        Application.Quit(); 


        Debug.Log("You have Exited the game");
    }
}
