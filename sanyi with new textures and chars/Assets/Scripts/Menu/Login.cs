using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using System.IO;

public class Login : MonoBehaviour
{
    private Player vars = new Player();
    public InputField nameField;
    public InputField passwordField;

    public Text errorTitle;
    public Text errorMessage;
    public GameObject registerError;
    public GameObject hideAble;
    public Button hideButton;



    public string[] userData;


    [Obsolete]
    public void loginBtn()
    {
        StartCoroutine(LoginToTheGame(nameField.text, passwordField.text));

    }

    [Obsolete]
    IEnumerator LoginToTheGame(string username, string pass)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", pass);
       
        
        using(UnityWebRequest www = UnityWebRequest.Post("https://sanyithegame.000webhostapp.com/Login.php", form))
        {
            yield return www.SendWebRequest();
            Debug.Log(www.downloadHandler.text);
           
            if (www.downloadHandler.text.Contains("0") && www.downloadHandler.text.Length < 2)
            {
                errorTitle.text = "Login error";
                hideAble.SetActive(false);
                registerError.SetActive(true);
                errorMessage.text = "Wrong Username or password!";
            }
            else if (www.downloadHandler.text.Contains("1") && www.downloadHandler.text.Length < 2)
            {
                errorTitle.text = "Login error";
                hideAble.SetActive(false);
                registerError.SetActive(true);
                errorMessage.text = "No user found!";
            }
            else if (www.isHttpError)
            {
                errorTitle.text = "Login error";
                Debug.Log(www.error);
                hideAble.SetActive(false);
                registerError.SetActive(true);
                errorMessage.text = "Http error!";

            }
            else if (www.isNetworkError)
            {
                errorTitle.text = "Login error";
                Debug.Log(www.error);
                hideAble.SetActive(false);
                registerError.SetActive(true);
                errorMessage.text = "No internet connection, try again!";

            }
            else if(www.downloadHandler.text.Contains("ID"))
            {
                string data = www.downloadHandler.text;

                DataReader reader = new DataReader();
                userData = data.Split(';');

                Debug.Log(www.downloadHandler.text);
                int score = Int32.Parse(reader.GetUserData(userData[0], "Score:"));
                int sCoins = Int32.Parse(reader.GetUserData(userData[0], "SanyiCoin:"));
                int coins = Int32.Parse(reader.GetUserData(userData[0], "Coins:"));
                int id = Int32.Parse(reader.GetUserData(userData[0], "ID:"));

                Player player = new Player();
                player.setCoinNumber(coins);
                player.setScore(score);
                player.setSCoinNumber(sCoins);
                player.setID(id);
                player.setUserName(nameField.text);

                SaveData save = new SaveData();

                save.Save(player);

                UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");

            }
            else
            {
               
                hideAble.SetActive(false);
                registerError.SetActive(true);
                errorTitle.text = "Login error";
                errorMessage.text = "There was a problem in the login procedure, please try again!";
            }
        }
    }

    public void HideErrorMessage()
    {
        hideAble.SetActive(true);
        registerError.SetActive(false);
    }



   public void RegisterBtn()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Register");
    }

    public void Quit()
    {
        Application.Quit();
    }


    
    
}
