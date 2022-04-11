using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateAroundYourself : MonoBehaviour
{
    private float rotateSpeed = 2f;//n alkalommal fordul körbe a saját Z tengelye körül másodpercenként

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed*  360*Time.deltaTime);//360 fok*n fordulás minden másodpercben, deltaTime miatt FPS független
        
    }
}
