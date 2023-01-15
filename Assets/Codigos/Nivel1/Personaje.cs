using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;

public class Personaje : MonoBehaviour
{
    private bool vistaDerecha = true;

    private Rigidbody2D rigidBody2D;
    private Animator animator;
    private float horizontal;
    private bool grounded;
    public int Energia=100;
    

    public float speed;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Energia == 0)
        {

            DestroyPersonaje();
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetBool("running",horizontal!=0.0f);
        if(horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            animator.SetBool("attack", false);
        }
        else
        {
            if (horizontal > 0.0f)
            {
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                animator.SetBool("attack", false);
            }
        }
        if(Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.P))
        {
            animator.SetBool("attack", true);
        }
    }
    private void FixedUpdate()
    {
        //A=izq D=dere
        rigidBody2D.velocity = new Vector2(horizontal, rigidBody2D.velocity.y);
    }
    private void Jump()
    {
        rigidBody2D.AddForce(Vector2.up*jumpForce);
    }
    public void DestroyPersonaje()
    {
        Thread.Sleep(2000);
        Destroy(gameObject);
    }


    public void Hit()
    {
        Energia -= 50;
        if (Energia == 0) Destroy(gameObject);
    }
}
