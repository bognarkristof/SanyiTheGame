using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    private bool GameIsPaused;
    public GameObject pausemenuUI;
    public Toggle mutetgl;

    Resolution[] resolutions;


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



    private void Start()
    {
        
        resolutions = Screen.resolutions;
        List<string> options = new List<string>();
        int currentRes = 0;
        resolutionDropdown.ClearOptions();

        for(int i = 0; i<resolutions.Length; i++)
        {
            //string option = "width" + "x" + "height";
            if(resolutions[i].width > 1280 && resolutions[i].height > 720)
            {
                string option = resolutions[i].width + "x" + resolutions[i].height;

                options.Add(option);
                if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                {
                    currentRes = i;
                }
            }
           
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentRes;
        resolutionDropdown.RefreshShownValue();

        audioMixer.SetFloat("volume", 0.3f);
    }

    public void Mute(bool isMute)
    {
        if (isMute)
        {
            audioMixer.SetFloat("volume", 0.3f);
        }
        else
        {
            audioMixer.SetFloat("volume", -80f);
        }
    }

    public void SetRes(int index)
    {
        Resolution res = resolutions[index];
        Screen.SetResolution(res.width, res.height, true);
    }


    public void SetFullscreen(bool isItFull)//dinamikus változóval állítjuk a teljes képernyõ beállítást
    {
        Screen.fullScreen = isItFull;
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

