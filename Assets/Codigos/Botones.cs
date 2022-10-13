using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    //Método de Inicio, no colar Start que es un método reservado

    public void Inicio()
    {
        SceneManager.LoadScene("PantallaInicio");
    }

    public void Comenzar()
    {
        SceneManager.LoadScene("0");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Credits");
    }



    public void Salir()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }


}