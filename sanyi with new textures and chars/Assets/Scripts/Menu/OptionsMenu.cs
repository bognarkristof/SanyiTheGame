using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;

    Resolution[] resolutions;
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
        Screen.SetResolution(res.width, res.height, true);
    }

    public void SetVolume (float volume)//dinamikus változóval állítjuk a hangerõt
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullscreen(bool isItFull)//dinamikus változóval állítjuk a teljes képernyõ beállítást
    {
        Screen.fullScreen = isItFull;
    }

}

