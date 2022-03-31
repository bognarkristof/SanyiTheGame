using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;



public class finish : MonoBehaviour
{

    private Player vars;
    private DataReader reader = new DataReader();
    playerlife pl = new playerlife();
    private AudioSource finishSound;
    private bool levelCompleted = false;
    private void Start()
    {
        

        finishSound = GetComponent<AudioSource>();
    }

    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            finishSound.Play();
            levelCompleted = true;
            StartCoroutine(UpdateValues());
            Invoke("CompleteLvL", 2f);
            
        }
    }

    [System.Obsolete]
    IEnumerator UpdateValues()
    {
        vars = reader.GetData();
        int scr =reader.ScoreMaker(pl.collectedPineapple, vars.getCoinNumber(), vars.getSCoinNumber());
        vars.setScore(scr);
        int score = vars.getScore();
        int scoin = vars.getSCoinNumber() + 5;
        int coin = vars.getCoinNumber();
        coin = coin + 50;
        vars.setSCoinNumber(scoin);
        vars.setCoinNumber(coin);

        WWWForm form = new WWWForm();
        form.AddField("id", vars.getID());
        form.AddField("coins", coin);
        form.AddField("scoins", scoin);
        form.AddField("score", score);
        Debug.Log(vars.getID());

        using (UnityWebRequest www = UnityWebRequest.Post("https://sanyithegame.000webhostapp.com/DataUpdate.php", form))
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
                Debug.Log(data);
            }
        }


        vars.setSCoinNumber(scoin);
        vars.setCoinNumber(coin);
        vars.setScore(score);
        SaveData save = new SaveData();
        save.Save(vars);
    }


    private void CompleteLvL()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
