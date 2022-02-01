using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using System.IO;

public class Login : MonoBehaviour
{
    private VariableScript vars = new VariableScript();
    public InputField nameField;
    public InputField passwordField;

    public Button submitBtn;

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

        using(UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityBackend/Login.php", form))
        {
            yield return www.SendWebRequest();

            if(www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                string data = www.downloadHandler.text;


                userData = data.Split(';');

                int steps = Int32.Parse(GetUserData(userData[0], "Steps:"));
                int sCoins = Int32.Parse(GetUserData(userData[0], "SanyiCoin:"));
                int coins = Int32.Parse(GetUserData(userData[0], "Coins:"));
                int id = Int32.Parse(GetUserData(userData[0], "ID:"));

                
                vars.setSteps(steps);
                vars.setSCoinNumber(sCoins);
                vars.setCoinNumber(coins);
                vars.setID(id);
                


                Debug.Log(vars.getID());
                Debug.Log(vars.getSCoinNumber());
                Debug.Log(vars.getCoinNumber());
                Debug.Log(vars.getSteps());

                
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
            }
        }
    }

   public void RegisterBtn()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Register");
    }

    public void Quit()
    {
        Application.Quit();
    }


    private string GetUserData(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);


        if (value.Contains("|"))
        {
            value = value.Remove(value.IndexOf("|"));
        }


        return value;
    }
    
}
