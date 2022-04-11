using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    public void QuitGame()//kilépés a játékból
    {

        Application.Quit();
    }

    public void ToLogin()//kilépés a játékból
    {

        SceneManager.LoadScene("Login");
    }
}

