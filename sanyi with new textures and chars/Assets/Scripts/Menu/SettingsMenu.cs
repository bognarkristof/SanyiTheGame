using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public static bool GameIsPaused = false;
    public GameObject pausemenuUI;
    Resolution[] resolutions;
    public Dropdown resolutionDropdown;
    public GameObject Player;
    public GameObject optionsmenuUI;

    /*
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/volume.txt", volume.ToString());
    }*/

    private void Start()
    {
        
        resolutions = Screen.resolutions;
        List<string> options = new List<string>();
        int currentRes = 0;
        resolutionDropdown.ClearOptions();

        for(int i = 0; i<resolutions.Length; i++)
        {
            //string option = "width" + "x" + "height";
            string option = resolutions[i].width + "x" + resolutions[i].height;

            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentRes = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentRes;
        resolutionDropdown.RefreshShownValue();

        
    }

    public void SetRes(int index)
    {
        Resolution res = resolutions[index];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

   

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
        Time.timeScale = 1f;
        GameIsPaused = false;
        
        
    }

    void Pause()
    {
        pausemenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        
        
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


}
