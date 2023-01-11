using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject personaje;
    private Vector3 posicionRelativa;
    void Start()
    {
        posicionRelativa = transform.position - personaje.transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x = personaje.transform.position.x;
        transform.position = position;
        //transform.position = personaje.transform.position + posicionRelativa;
    }
}
