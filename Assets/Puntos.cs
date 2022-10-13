using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntos : MonoBehaviour{
    public static int ValPuntos = 0;
    public Text PunTos;
    void Start(){
        PunTos = GetComponent<Text>();
    }
    void Update(){
        PunTos.text = "Puntos : " + ValPuntos;
    }

}

//ESTE CODIGO COLOCARLO EN EL CANVAS DONDE VIENE EL TEXTO, PONER EL COMPONENTE