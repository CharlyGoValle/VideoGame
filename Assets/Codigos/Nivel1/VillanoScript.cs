using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class VillanoScript : MonoBehaviour
{
    Animator anim;
    public GameObject personaje;
    public Transform target; // the main character

    /*void OnCollisionEnter2D(Collision2D contacto)
    {
        if (contacto.gameObject.tag == "Player")
        {
            contacto.gameObject.GetComponent<Personaje>().Hit();
        }
        if (Energia == 0)
        {
            Destroy(contacto.gameObject);
        }
        Energia = Energia - 1;
    }
    void OnTriggerEnter2D(Collider2D contacto)
    {
        /*if (contacto.gameObject.tag == "Player")
        {
            contacto.gameObject.GetComponent<Personaje>().Hit();
        }
        if (Energia == 0)
        {
            Destroy(contacto.gameObject);
        }
        Energia = Energia - 1;
    }*/

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
