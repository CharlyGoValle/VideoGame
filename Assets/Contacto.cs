using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Libreria que se encarga de administrar escenas


public class Contacto : MonoBehaviour
{
    public GameObject personaje;
    public Transform target; // the main character

    void OnCollisionEnter2D(Collision2D contacto)
    {
        if (contacto.gameObject.tag == "Player")
        {
            contacto.gameObject.GetComponent<Player>().Energia = 0;
        }
        if (contacto.gameObject.tag == "Adv")
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
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime);
        }
        else
        {
            if (personaje == null) return;
            Vector3 direction = personaje.transform.position - transform.position;
            if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        }
    }


}
