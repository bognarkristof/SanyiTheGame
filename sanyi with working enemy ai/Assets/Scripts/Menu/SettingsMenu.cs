using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public static bool GameIsPaused = false;
    public GameObject pausemenuUI;
    public GameObject optionsmenuUI;
    public GameObject Player;

    

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");

    }

    public void CloseGame()
    {
        Application.Quit();
    }


    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(optionsmenuUI.activeSelf == true)
            {
                optionsmenuUI.SetActive(false);
            }
            if (GameIsPaused == true)
            {
                Resume();

            }
            else
            {
                Pause();
            }
        }
            
    }

    public void Resume()
    {
        pausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Player.SetActive(true);
        
    }

    void Pause()
    {
        pausemenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Player.SetActive(false);
        
    }


}
