using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateAroundYourself : MonoBehaviour
{
    private float rotateSpeed = 2f;//n alkalommal fordul k�rbe a saj�t Z tengelye k�r�l m�sodpercenk�nt

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed*  360*Time.deltaTime);//360 fok*n fordul�s minden m�sodpercben, deltaTime miatt FPS f�ggetlen
        
    }
}
