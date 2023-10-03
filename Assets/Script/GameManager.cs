using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isEnd = false;

    // Public list of Colors used for various game elements.
    public List<Color> colors = new();

    // Static reference to the GameManager instance, allowing easy access from other scripts.
    public static GameManager Instance;

    [SerializeField] private GameObject gameOver;

    int index;

    void Awake()
    {
        // Assign this instance as the GameManager's singleton instance.
        Instance = this;
    }

    public Color RandomColor() 
    {
       // Generate a random index within the bounds of the 'colors' list.
       index = Random.Range(0, colors.Count);

       // Return the randomly selected color.
       return colors[index];
    }

    public GameObject PlayerTag()
    {
        // Find and return the GameObject with the "Player" tag.
        return GameObject.FindGameObjectWithTag("Player");
    }

    public void GameStatus(bool status) 
    {
        // Update the 'isEnd' variable to reflect the game status.
        isEnd = status;

        // Activate or deactivate the 'gameOver' GameObject to show or hide the game over screen.
        gameOver.SetActive(status);

        // Adjust the time scale to pause or resume the game based on the 'status'
        Time.timeScale = 0;
    }
}
