using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    
    
    private void Start()
    {
        
    }

    public void PlayGame ()//k�vetkez� scene elind�t�sa
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+ 1);
    }


    public void QuitGame()//kil�p�s a j�t�kb�l
    {
        
        Application.Quit();
    }




    





}
