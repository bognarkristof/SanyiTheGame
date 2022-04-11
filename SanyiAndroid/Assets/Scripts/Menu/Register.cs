using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class Register : MonoBehaviour
{
    public InputField usernameField;
    public InputField passwordField;
    public InputField emailField;
    public InputField firstNameField;
    public InputField lastNameField;
    public InputField registAge;

    public GameObject errorPanel;
    public GameObject registerPanel;

    public Text errorLabel;
    public Text errorMessage;


    public Button close;


    [System.Obsolete]
    public void RegisterBtn()
    {
        
        bool Ischecked = FilledCheck(usernameField.text, passwordField.text, emailField.text, firstNameField.text, lastNameField.text, registAge.text);
        if (Ischecked && Convert.ToInt32(registAge.text) >= 10)
        {
            
            StartCoroutine(Regist(usernameField.text, passwordField.text, emailField.text, firstNameField.text, lastNameField.text, registAge.text));
        }
        else
        {
            registerPanel.SetActive(false);
            errorPanel.SetActive(true);
            errorMessage.text = "Please, fill every field and be atleast 10 years old!";
        }
        
    }

    
    [System.Obsolete]
    IEnumerator Regist(string username, string pass, string email,string first, string last,string registAge )
    {
       
        string fullname = first + " " + last;
        WWWForm form = new WWWForm();
        form.AddField("registUser", username);
        form.AddField("registPass", pass);
        form.AddField("registEmail", email);
        form.AddField("registFullname", fullname);
        form.AddField("registAge", registAge);
        
        

        using (UnityWebRequest www = UnityWebRequest.Post("https://sanyithegame.000webhostapp.com/Register.php", form))
        {
            yield return www.SendWebRequest();

            
            if(www.downloadHandler.text.Contains("0"))
            {
                Debug.Log(www.error);
                registerPanel.SetActive(false);
                errorPanel.SetActive(true);
                errorLabel.text = "Registration error";
                errorMessage.text = "username already taken!";
            }
            else if(www.downloadHandler.text.Contains("2"))
            {
                Debug.Log(www.error);
                registerPanel.SetActive(false);
                errorPanel.SetActive(true);
                errorMessage.text = "Something went wrong during registration!";
            }
            else if (www.isHttpError)
            {
                Debug.Log(www.error);
                registerPanel.SetActive(false);
                errorPanel.SetActive(true);
                errorMessage.text = "Http error!";
            }
            else if (www.isNetworkError)
            {
                Debug.Log(www.error);
                registerPanel.SetActive(false);
                errorPanel.SetActive(true);
                errorMessage.text = " Network error!";
            }
            else if(www.downloadHandler.text.Contains("1"))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Login");
            }else
            {
                Debug.Log(www.error);
                registerPanel.SetActive(false);
                errorPanel.SetActive(true);
                errorMessage.text = "Something went wrong during registration!";
            }
        }

    }


    public bool FilledCheck(String usernameField, String passwordField, String emailField, String firstNameField, String lastNameField, String registAge)
    {
        bool isChecked;

        if (usernameField.Length == 0 || passwordField.Length == 0 || emailField.Length == 0 || firstNameField.Length == 0 || lastNameField.Length == 0 || registAge.Length == 0)
        {
            isChecked = false;
        }
        else
        {
            isChecked = true;
        }

        return isChecked;
    }
    public void HideErrorMessage()
    {
        registerPanel.SetActive(true);
        errorPanel.SetActive(false);
    }

    public void Privacy()
    {
        Application.OpenURL("https://sanyithegame.000webhostapp.com/privacy.php");
    }

   
}
