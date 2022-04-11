using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;



public class finish : MonoBehaviour
{

    private Player vars;
    private DataReader reader = new DataReader();
    playerlife pl = new playerlife();
    private bool levelCompleted = false;
   

    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            
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

        using (UnityWebRequest www = UnityWebRequest.Post("https://sanyithegame.000webhostapp.com/DataUpdate.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string data = www.downloadHandler.text;
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
