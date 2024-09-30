using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static bool Paused = false;
    public GameObject PauseMenuCanvas;
    public LevelUpManager LevelUpManager;

    // Update is called once per frame
    void Start()
    {
        Time.timeScale = 1f;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }
    }
    void Stop()
    {
        PauseMenuCanvas.SetActive(true);
            //Time.timeScale = 0f;
            LevelUpManager.Pause();
        Paused = true;
    }

    public void Play()
    {
        PauseMenuCanvas.SetActive(false);
       // Time.timeScale = 1f;
       LevelUpManager.Resume();
        Paused = false;
        Debug.Log("Game resumed, Time.timeScale set to 1.");

    }

    public void MainMenuButton()
    {
        Debug.Log("Game resumed, Time.timeScale set to 1.");
        SceneManager.LoadScene(0);
    }
}
