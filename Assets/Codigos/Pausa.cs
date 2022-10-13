using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public GameObject PanelPausa;
    public bool JuegoEnPausa = true;

    public void Reanudar()
    {
        PanelPausa.SetActive(false);
        JuegoEnPausa = false;
        Time.timeScale = 1f;    //detiene el reloj interno de unity //0 apagado //1 encendido
    }

    public void Salir()
    {
        SceneManager.LoadScene("PantallaInicio");
    }

    public void Pausar()
    {
        PanelPausa.SetActive(true);
        JuegoEnPausa = true;
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(JuegoEnPausa) //quitar la pausa
                Reanudar();
            else
                Pausar();
        }

    }
}