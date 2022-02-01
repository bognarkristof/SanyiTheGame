using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VariableScript : MonoBehaviour
{

    public Text data;

    private int CoinNumber;
    private int SCoinNumber;
    private int Steps;
    private string userName;
    private int ID;


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

    public int getSteps(){
        return this.Steps;
    }

    public void setSteps(int Steps){
        this.Steps = Steps;
    }


    private void Start()
    {
        Debug.Log(getCoinNumber());
        Debug.Log(getSteps());
        Debug.Log(getID());
        Debug.Log(getSCoinNumber());

        data.text = "sasdasd" + getUserName().ToString() + " " + getSteps().ToString() + " " + getID().ToString();
    }

}
