using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{

    [SerializeField]private Transform player;//ide kell behelyezni Editoron bel�l a k�vetni k�v�nt gameObjectet

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);//obejktum lek�vet�se x �s y tengelyen, z tengely marad a kamera alaphelyzete
    }
}
