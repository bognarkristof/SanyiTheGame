using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataReader : MonoBehaviour
{
    public string GetUserData(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);


        if (value.Contains("|"))
        {
            value = value.Remove(value.IndexOf("|"));
        }


        return value;
    }

    

    // Start is called before the first frame update
    public Player GetData()
    {
       
        string test = System.IO.File.ReadAllText(Application.persistentDataPath + "/PlayerData.txt");

        Debug.Log(test);
        Player player = new Player();

        int score = Int32.Parse(GetUserData(test, "score:"));
        int sCoins = Int32.Parse(GetUserData(test, "scoin:"));
        int coins = Int32.Parse(GetUserData(test, "coin:"));
        int id = Int32.Parse(GetUserData(test, "ID:"));
        string username = (GetUserData(test, "username:"));

        player.setID(id);
        player.setUserName(username);
        player.setCoinNumber(coins);
        player.setSCoinNumber(sCoins);
        player.setScore(score);

        return player;

    }


    public int ScoreMaker(int pineapple, int coin, int scoin)
    {
        
        return ((pineapple * 10 + 10) + coin + scoin);
    }
    
}
