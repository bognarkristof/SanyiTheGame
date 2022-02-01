using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollted : MonoBehaviour
{
    private VariableScript vars = new VariableScript();
    private int collectedPineapple;

    [SerializeField] private Text coin;
    [SerializeField] private Text steps;
    [SerializeField] private Text scoin;
    [SerializeField] private AudioSource collectedSound;


    private void Update()
    {
        steps.text = "Steps: " + vars.getSteps();
        scoin.text = "Sanyi Coins: " + vars.getSCoinNumber();

        collectedPineapple = vars.getCoinNumber();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("collectablePineapple"))
        {
            Destroy(collision.gameObject);
            collectedPineapple++;
            vars.setCoinNumber(collectedPineapple);
            coin.text = "Coin : " + collectedPineapple;
            collectedSound.Play();
        }
    }
}
