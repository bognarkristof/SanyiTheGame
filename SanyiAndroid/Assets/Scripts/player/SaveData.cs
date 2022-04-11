using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
   public void Save(Player player)
    {
        string data = "ID:" + player.getID() + "|score:" + player.getScore() + "|scoin:" + player.getSCoinNumber() + "|coin:" + player.getCoinNumber() + "|username:" + player.getUserName();

        string username = Environment.UserName;
        System.IO.File.WriteAllText(Application.persistentDataPath+ "/PlayerData.txt", data);
    }
}
