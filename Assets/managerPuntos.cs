using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerPuntos : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "objeto")
        {
            Puntos.ValPuntos += 10;
            Destroy(col.gameObject);
        }
    }

}