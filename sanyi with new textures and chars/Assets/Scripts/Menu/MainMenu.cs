using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame ()//k�vetkez� scene elind�t�sa
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+ 1);
    }


    public void QuitGame()//kil�p�s a j�t�kb�l
    {
        
        Application.Quit();
    }



}
