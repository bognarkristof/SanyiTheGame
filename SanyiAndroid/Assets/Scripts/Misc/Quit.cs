using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    public void QuitGame()//kil�p�s a j�t�kb�l
    {

        Application.Quit();
    }

    public void ToLogin()//kil�p�s a j�t�kb�l
    {

        SceneManager.LoadScene("Login");
    }
}

