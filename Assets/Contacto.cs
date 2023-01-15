using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Libreria que se encarga de administrar escenas

public class Contacto : MonoBehaviour
{
    public GameObject Personaje;

    void Update()
    {
        if (Personaje == null) return;

        Vector3 direction = Personaje.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        
    }
    void OnCollisionEnter2D(Collision2D contacto)
    {
        if (contacto.gameObject.tag == "Player")
        {
            contacto.gameObject.GetComponent<Player>().Energia = 0;
        }
        if (contacto.gameObject.tag == "Personaje")
        {
            contacto.gameObject.GetComponent<Personaje>().Hit();
        }
    }
    void OnTriggerEnter2D(Collider2D contacto)
    {
        if (contacto.gameObject.tag == "Player")
        {
            contacto.gameObject.GetComponent<Player>().Energia = 0;
        }
        if (contacto.gameObject.tag == "Personaje")
        {
            contacto.gameObject.GetComponent<Personaje>().Energia = 0;
        }
    }

}
