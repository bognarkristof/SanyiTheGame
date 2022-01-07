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
    
    private void Start()//azért nem List<Resolution> ként mentjük mert az AddOptions függvény csak egy string listát fogad el, ebben az esetben nem string listát hoznánk létre
    {
        resolutions = Screen.resolutions; //képernyõfelbontások mentése egy tömbbe

        resolutionDropdown.ClearOptions();//jelenlegi dropdown menü beállításainak törlése
        List<string> options = new List<string>();
        int currentresolutionIndex = 0;
        for(int i = 0; i< resolutions.Length; i++)//egy listához adjuk hozzá a lehetséges felbontásokat
        {
            string option = resolutions[i].width + " X " + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)//ha a jelenlegi felbontás megegyezik az egyik elemmel akkor az lesz kiválasztva alapból
            {
                currentresolutionIndex = i;
            }
        }


        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentresolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)//felbontás és teljes képernyõ beállítása
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
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
