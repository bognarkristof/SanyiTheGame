using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;



public class finish : MonoBehaviour
{

    private VariableScript vars = new VariableScript();
    private AudioSource finishSound;
    private bool levelCompleted = false;
    private void Start()
    {
        

        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" || collision.gameObject.name == "Player_Hero" || collision.gameObject.name == "Player_Bandit")
        {
            finishSound.Play();
            levelCompleted = true;
            StartCoroutine(UpdateValues());
            Invoke("CompleteLvL", 3f);
            
        }
    }




    IEnumerator UpdateValues()
    {
        int steps = vars.getSteps();
        int scoin = vars.getSCoinNumber() + 50;
        int coin = vars.getCoinNumber() + 500;
        
        Debug.Log(steps);
        Debug.Log(scoin);
        Debug.Log(coin);
        Debug.Log(vars.getID());
       

        WWWForm form = new WWWForm();
        form.AddField("id", vars.getID());
        form.AddField("coins", coin);
        form.AddField("scoins", scoin);
        form.AddField("steps", steps);
        

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityBackend/DataUpdate.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                string data = www.downloadHandler.text;

            }
        }
    }






    private void CompleteLvL()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
