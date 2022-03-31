using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class UnitTests
{
   
    [Test]
    public void VariableScriptSetId()
    {
        int expected = 1;

        Player obj = new Player();

        obj.setID(expected);
        int actual = obj.getID();
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void VariableScriptSetScore()
    {
        int expected = 1;

        Player obj = new Player();

        obj.setScore(expected);
        int actual = obj.getScore();

        Assert.AreEqual(expected, actual);

    }

    [Test]
    public void VariableScriptSetUsername()
    {
        string expected = "Sanyi";

        Player obj = new Player();

        obj.setUserName(expected);
        string actual = obj.getUserName();

        Assert.AreEqual(expected, actual);

    }

    [Test]
    public void VariableScriptSetCoinNumber()
    {
        int expected = 5;

        Player obj = new Player();

        obj.setCoinNumber(expected);
        int actual = obj.getCoinNumber();

        Assert.AreEqual(expected, actual);

    }

    [Test]
    public void VariableScriptSetSCoinNumber()
    {
        int expected = 3;

        Player obj = new Player();

        obj.setSCoinNumber(expected);
        int actual = obj.getSCoinNumber();

        Assert.AreEqual(expected, actual);

    }

    [Test]
    public void RegisterFilledCheck()
    {
        bool expected = true;

        Register obj = new Register();
        string username = "sanyi";
        string password = "asd";
        string email = "asd@asd.com";
        string age = "11";
        string fristname = "kovacs";
        string lastname = "sanyi";



        bool actual = obj.FilledCheck(username, password, email, age, fristname, lastname);//has to be true

        Assert.AreEqual(expected, actual);

    }

    [Test]
    public void DataReaderGetUserData()
    {
        DataReader reader = new DataReader();
        Player player = new Player();
        string[] userdata;
        string data = "score:1|coin:2;";

        userdata = data.Split(';');
        int score = Int32.Parse(reader.GetUserData(userdata[0], "score:"));
        int coin = Int32.Parse(reader.GetUserData(userdata[0], "coin:"));

        Assert.AreEqual(score, 1);
        Assert.AreEqual(coin, 2);
    }

    [Test]
    public void DataReaderGetData()
    {
        string test = System.IO.File.ReadAllText(Application.persistentDataPath + "/PlayerData.txt");


        Player player = new Player();
        
        
        DataReader reader = new DataReader();

        int score = Int32.Parse(reader.GetUserData(test, "score:"));
        int sCoins = Int32.Parse(reader.GetUserData(test, "scoin:"));
        int coins = Int32.Parse(reader.GetUserData(test, "coin:"));
        int id = Int32.Parse(reader.GetUserData(test, "ID:"));
        string username = (reader.GetUserData(test, "username:"));




        player.setID(id);
        player.setUserName(username);
        player.setCoinNumber(coins);
        player.setSCoinNumber(sCoins);
        player.setScore(score);

        Assert.AreEqual(player.getID(), id);
        Assert.AreEqual(player.getUserName(), username);
        Assert.AreEqual(player.getSCoinNumber(), sCoins);
        Assert.AreEqual(player.getCoinNumber(), coins);
        Assert.AreEqual(player.getScore(), score);
        


    }

    [Test]
    public void SaveDataSaveTest()
    {
        string test = System.IO.File.ReadAllText(Application.persistentDataPath + "/PlayerData.txt");


        Player player = new Player();
        DataReader reader = new DataReader();

        int score = Int32.Parse(reader.GetUserData(test, "score:"));
        int sCoins = Int32.Parse(reader.GetUserData(test, "scoin:"));
        int coins = Int32.Parse(reader.GetUserData(test, "coin:"));
        int id = Int32.Parse(reader.GetUserData(test, "ID:"));
        string username = (reader.GetUserData(test, "username:"));

        player.setID(id);
        player.setUserName(username);
        player.setCoinNumber(coins);
        player.setSCoinNumber(sCoins);
        player.setScore(score);

        SaveData save = new SaveData();

        save.Save(player);

        Player player2 = new Player();
        int score2 = Int32.Parse(reader.GetUserData(test, "score:"));
        int sCoins2 = Int32.Parse(reader.GetUserData(test, "scoin:"));
        int coins2= Int32.Parse(reader.GetUserData(test, "coin:"));
        int id2 = Int32.Parse(reader.GetUserData(test, "ID:"));
        string username2 = (reader.GetUserData(test, "username:"));




        player2.setID(id2);
        player2.setUserName(username2);
        player2.setCoinNumber(coins2);
        player2.setSCoinNumber(sCoins2);
        player2.setScore(score2);


        Assert.AreEqual(player2.getID(), player2.getID());
        Assert.AreEqual(player.getUserName(), player2.getUserName());
        Assert.AreEqual(player.getSCoinNumber(), player2.getSCoinNumber());
        Assert.AreEqual(player.getCoinNumber(), player2.getCoinNumber());
        Assert.AreEqual(player.getScore(), player2.getScore());
    }



}
