using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    //function to start the game
	public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // function to quit the game
    public void QuitGame()
    {
        Debug.Log("Game quited");
        Application.Quit();
    }
}
