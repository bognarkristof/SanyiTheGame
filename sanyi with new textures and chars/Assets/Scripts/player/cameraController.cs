using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{

    [SerializeField]private Transform player;//ide kell behelyezni Editoron belül a követni kívánt gameObjectet

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);//obejktum lekövetése x és y tengelyen, z tengely marad a kamera alaphelyzete
    }
}
