using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Register : MonoBehaviour
{
    public InputField usernameField;
    public InputField passwordField;
    public InputField emailField;
    public InputField firstNameField;
    public InputField lastNameField;


    public Button submitBtn;
    public void RegisterBtn()
    {
        StartCoroutine(Regist(usernameField.text, passwordField.text, emailField.text, firstNameField.text, lastNameField.text));
    }

    IEnumerator Regist(string username, string pass, string email,string first, string last)
    {
        
        string fullname = first + "" + last;
        WWWForm form = new WWWForm();
        form.AddField("registUser", username);
        form.AddField("registPass", pass);
        form.AddField("registEmail", email);
        form.AddField("registFullname", fullname);
        

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityBackend/Register.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }

    }
}
