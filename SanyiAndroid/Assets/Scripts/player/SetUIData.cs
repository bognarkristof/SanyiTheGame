using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUIData : MonoBehaviour
{

    [SerializeField] private Text coin;
    [SerializeField] private Text scoin;
    [SerializeField] private Text score;
    [SerializeField] private AudioSource collectedSound;

    DataReader reader = new DataReader();


    Player player;

    private void Start()
    {
        player = reader.GetData();
        scoin.text = "Sanyi Coins: " + player.getSCoinNumber();
        coin.text = "Coins: " + player.getCoinNumber();
        score.text = "Score: " + player.getScore();
    }

    
}

 
