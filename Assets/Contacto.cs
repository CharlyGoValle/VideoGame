using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Libreria que se encarga de administrar escenas

public class Contacto : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D contacto)
    {
        if (contacto.gameObject.tag == "Player")
        {
            contacto.gameObject.GetComponent<Player>().Energia = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D contacto)
    {
        if (contacto.gameObject.tag == "Player")
        {
            contacto.gameObject.GetComponent<Player>().Energia = 0;
        }
    }

}
