using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player: MonoBehaviour
{

    public Text data;

    public int ID;
    public string userName;
    public int Score;
    public int CoinNumber;
    public int SCoinNumber;


    public void setID(int id)
    {
        this.ID = id;
    }
    public int getID()
    {
        return this.ID;
    }


    public string getUserName()
    {
        return this.userName;
    }

    public void setUserName(string username)
    {
        this.userName = username;
    }

    public int getCoinNumber(){
        return this.CoinNumber;
    }

    public void setCoinNumber(int CoinNumber){   
        this.CoinNumber = CoinNumber;
    }

    public int getSCoinNumber(){
        return this.SCoinNumber;
    }

    public void setSCoinNumber(int SCoinNumber){
        this.SCoinNumber = SCoinNumber;
    }

    public int getScore(){
        return this.Score;
    }

    public void setScore(int score){
        this.Score = score;
    }


}
