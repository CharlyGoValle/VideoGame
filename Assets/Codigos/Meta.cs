using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Meta : MonoBehaviour
{

	void OnCollisionEnter2D(Collision2D contacto1)
	{
		if (contacto1.gameObject.tag == "contacto1")
		{
			SceneManager.LoadScene("FinJuego");
		}
	}

    public IEnumerator cambioEscena()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("FinJuego");
    }

}