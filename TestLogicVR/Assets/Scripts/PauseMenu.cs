using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseMenuUI;
    //private Button pauseButton;

    void Update()
    {
        //how to stop constant check
        if(pauseMenuUI.activeSelf)
        {
            Debug.Log("ACTIVE!!!");
            if (gamePaused)
            {
                Debug.Log("NOT PAUSED!!!");
                Resume();
            }
            else 
            {
                Debug.Log("PAUSED!!!");
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }
    /*
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        //Application.Quit();
    }
    */
}
