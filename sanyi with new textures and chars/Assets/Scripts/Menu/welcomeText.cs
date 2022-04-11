using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class welcomeText : MonoBehaviour
{

    public Text mainMenuText;
    // Start is called before the first frame update
    void Start()
    {
        DataReader read = new DataReader();
        Player player = read.GetData();

        mainMenuText.text = "Hi, " + player.getUserName() + "!";

    }

}
