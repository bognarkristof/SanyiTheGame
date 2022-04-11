using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginInputFieldTab : MonoBehaviour
{
    public InputField username;//0
    public InputField pass;//1
    

    private int inputSelected;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKeyDown(KeyCode.LeftShift))
        {
            inputSelected--;
            if (inputSelected < 0) inputSelected = 0;
            SelectInputField(inputSelected);
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            inputSelected++;
            if (inputSelected > 1) inputSelected = 0;
            SelectInputField(inputSelected);
        }

    }

    private void SelectInputField(int selected)
    {
        switch (selected)
        {
            case 0:
                username.Select();
                break;
            case 1:
                pass.Select();
                break;
        }
    }
}
