using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollted : MonoBehaviour
{

    private int collectedPineapple=0;

    [SerializeField] private Text score;
    [SerializeField] private AudioSource collectedSound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("collectablePineapple"))
        {
            Destroy(collision.gameObject);
            collectedPineapple++;
            score.text = "Score: " + collectedPineapple;
            collectedSound.Play();
        }
    }
}
