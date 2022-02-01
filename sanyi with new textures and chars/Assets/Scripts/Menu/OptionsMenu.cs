using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    public List<ResItems> res = new List<ResItems>();
    public Text screenResText;


    private int selectedRes;
    private void Start()
    {
        
    }
    public void ResLeft()
    {
        selectedRes--;
        if(selectedRes > 0)
        {
            selectedRes = 0;
        }
        UpdateResLabel();
    }

    public void ResRight()
    {
        selectedRes++;
        if(selectedRes >res.Count - 1)
        {

            selectedRes = res.Count - 1;
        }
        UpdateResLabel();
        SetRes();
    }

    public void SetVolume (float volume)//dinamikus változóval állítjuk a hangerõt
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullscreen(bool isItFull)//dinamikus változóval állítjuk a teljes képernyõ beállítást
    {
        Screen.fullScreen = isItFull;
    }

    public void UpdateResLabel()
    {
        screenResText.text = res[selectedRes].horizontal.ToString() + " x " + res[selectedRes].vertical.ToString();
        SetRes();
    }

    public void SetRes()
    {
        Screen.SetResolution(res[selectedRes].horizontal, res[selectedRes].vertical, true);
    }
}

[System.Serializable]
public class ResItems
{
    public int horizontal, vertical;
}
