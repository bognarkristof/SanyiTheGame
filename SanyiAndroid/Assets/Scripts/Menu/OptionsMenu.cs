using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    private bool GameIsPaused;
    public GameObject pausemenuUI;
    public Toggle mutetgl;
    public GameObject gameUI;



    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

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
        gameUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;


    }

    void Pause()
    {
        pausemenuUI.SetActive(true);
        gameUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;


    }



    private void Start()
    {
        
        audioMixer.SetFloat("volume", -20f);
    }

    public void Mute(bool isMute)
    {
        if (isMute)
        {
            audioMixer.SetFloat("volume", -20f);
        }
        else
        {
            audioMixer.SetFloat("volume", -80f);
        }
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

}

