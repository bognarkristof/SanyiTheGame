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
    
    private void Start()//az�rt nem List<Resolution> k�nt mentj�k mert az AddOptions f�ggv�ny csak egy string list�t fogad el, ebben az esetben nem string list�t hozn�nk l�tre
    {
        resolutions = Screen.resolutions; //k�perny�felbont�sok ment�se egy t�mbbe

        resolutionDropdown.ClearOptions();//jelenlegi dropdown men� be�ll�t�sainak t�rl�se
        List<string> options = new List<string>();
        int currentresolutionIndex = 0;
        for(int i = 0; i< resolutions.Length; i++)//egy list�hoz adjuk hozz� a lehets�ges felbont�sokat
        {
            string option = resolutions[i].width + " X " + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)//ha a jelenlegi felbont�s megegyezik az egyik elemmel akkor az lesz kiv�lasztva alapb�l
            {
                currentresolutionIndex = i;
            }
        }


        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentresolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)//felbont�s �s teljes k�perny� be�ll�t�sa
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void SetVolume (float volume)//dinamikus v�ltoz�val �ll�tjuk a hanger�t
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullscreen(bool isItFull)//dinamikus v�ltoz�val �ll�tjuk a teljes k�perny� be�ll�t�st
    {
        Screen.fullScreen = isItFull;
    }
}
