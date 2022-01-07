using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;




public class Login : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;
    

    public Button submitBtn;


    
    public void loginBtn()
    {
        StartCoroutine(LoginToTheGame(nameField.text, passwordField.text));
    }


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
    
}
