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

    public void PlayGame ()//következõ scene elindítása
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+ 1);
    }


    public void QuitGame()//kilépés a játékból
    {
        
        Application.Quit();
    }




    





}
