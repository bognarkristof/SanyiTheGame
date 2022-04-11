using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabInputField : MonoBehaviour
{
    public InputField username;//0
    public InputField pass;//1
    public InputField fname;//2
    public InputField lname;//3
    public InputField email;//4
    public InputField age;//5

    private int inputSelected;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && Input.GetKeyDown(KeyCode.LeftShift))
        {
            inputSelected--;
            if (inputSelected < 0) inputSelected = 0;
            SelectInputField(inputSelected);
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            inputSelected++;
            if (inputSelected > 5) inputSelected = 0;
            SelectInputField(inputSelected);
        }

    }

    private void SelectInputField(int selected)
    {
        switch (selected)
        {
            case 0: username.Select();
                break;
            case 1: pass.Select();
                break;
            case 2: fname.Select();
                break;
            case 3: lname.Select();
                break;
            case 4: email.Select();
                break;
            case 5: age.Select();
                break;
        }
    }
}
