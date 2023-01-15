using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //User Interface
using UnityEngine.SceneManagement; //Libreria que se encarga de administrar escenas

public class Player : MonoBehaviour
{
    Animator anim;
    bool viendoDercha = true;

    private Rigidbody2D cuerpo;
    public bool pisando = false;
    public LayerMask queEspiso;
    public Transform pies;
    public float speed;

    public Transform MainCamera;
    public Transform Aventurero;

    float radioPies = 0.2f;
    public int Energia;
    public float fuerzaSalto = 1f;
    AudioSource efectos;
    public AudioClip caminar;
    public AudioClip Ataque1;
    public AudioClip Ataque2;
    public AudioClip Salto;
    public AudioClip Morir;


    public bool vivo = true;

    public Text energiaPts;
    public Slider energiaBarra;
    


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        cuerpo = GetComponent<Rigidbody2D>();
        efectos = GetComponent<AudioSource>();
        Energia = 100;
    }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "objeto")
            {
                Puntos.ValPuntos += 10;
                Destroy(col.gameObject);
            }
        }


        // Update is called once per frame
        void Update()
    {


        if (vivo)
        {

            if (MainCamera.position.y > Aventurero.position.y+3)
            {
                Energia = 0;
            }

            anim.SetBool("vida", vivo);
            if (Energia <= 0 && pisando)
            {
                Energia = 0;
                anim.Play("Morir");
                efectos.clip = Morir;
                efectos.Play();
                vivo = false;
                Puntos.ValPuntos = 0;
                cambioEscena();
            }

            if (Input.GetKey(KeyCode.P))
            {
                anim.Play("Ataque1");
                efectos.clip = Ataque1;
                efectos.Play();
            }

            if (Input.GetKey(KeyCode.O))
            {
                anim.Play("Ataque2");
                efectos.clip = Ataque2;
                efectos.Play();
            }



            float mover = Input.GetAxis("Horizontal");
            anim.SetFloat("vel", Mathf.Abs(mover));
            cuerpo.velocity = new Vector2(mover*(5f*speed), cuerpo.velocity.y);
            
            if (viendoDercha && mover < 0)
            {
                InvertirDibujo();
                efectos.clip = caminar;
                efectos.Play();
                efectos.Stop();
            }
            if (!viendoDercha && mover > 0)
            {
                efectos.clip = caminar;
                efectos.Play();
                InvertirDibujo();
                efectos.Stop();

            }

            pisando = Physics2D.OverlapCircle(pies.position, radioPies, queEspiso);

            if (Input.GetKey(KeyCode.UpArrow) && pisando)
            {
                efectos.clip = Salto;
                efectos.Play();
                cuerpo.AddForce(new Vector2(0, fuerzaSalto));
            }

            anim.SetBool("pisar", pisando);
           anim.SetFloat("alt", cuerpo.velocity.y);
        }
     
    }

    void InvertirDibujo()
    {
        viendoDercha = !viendoDercha;
        Vector3 escalas = transform.localScale;
        escalas.x *= -1;
        transform.localScale = escalas;
    }


        public IEnumerator cambioEscena()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("0");
    }
}