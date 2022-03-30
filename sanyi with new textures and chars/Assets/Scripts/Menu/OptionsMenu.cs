using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    public Slider slider;

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

        if (System.IO.File.ReadAllText(Application.persistentDataPath + "/volume.txt") == null)
        {
            float tempVolume = 0.33f;
            SetVolume(tempVolume);
            Debug.Log("nulla");
            slider.value = tempVolume;
        }
        else
        {
            Debug.Log("nem nulla");
            SetVolume(float.Parse(System.IO.File.ReadAllText(Application.persistentDataPath + "/volume.txt"))); 
            Debug.Log(System.IO.File.ReadAllText(Application.persistentDataPath + "/volume.txt"));
            slider.value=float.Parse(System.IO.File.ReadAllText(Application.persistentDataPath + "/volume.txt"));
        }
    }

    public void SetRes(int index)
    {
        Resolution res = resolutions[index];
        Screen.SetResolution(res.width, res.height, true);
    }

    public void SetVolume (float volume)//dinamikus változóval állítjuk a hangerõt
    {
        audioMixer.SetFloat("volume", volume);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/volume.txt", volume.ToString());
        Debug.Log(volume);
       
        
    }

    public void SetFullscreen(bool isItFull)//dinamikus változóval állítjuk a teljes képernyõ beállítást
    {
        Screen.fullScreen = isItFull;
    }

}

