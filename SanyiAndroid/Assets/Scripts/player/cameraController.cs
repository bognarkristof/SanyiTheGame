using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{

    [SerializeField]private Transform player;//ide kell behelyezni Editoron belül a követni kívánt gameObjectet
    public float zoom = 12f;


    private void Start()
    {
        zoom = 12f;
        GetComponent<Camera>().orthographicSize = zoom;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        
        
        Vector3 temp = transform.position;//jelenlegi kamera helyzet

        temp.x = player.position.x;
        temp.y = player.position.y;

        transform.position = temp;

         

        
    }
}
