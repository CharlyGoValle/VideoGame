using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Personaje : MonoBehaviour
{
    private bool vistaDerecha = true;

    private Rigidbody2D rigidBody2D;
    private Animator animator;
    private float horizontal;
    private bool grounded;
    

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

        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetBool("running",horizontal!=0.0f);
        if(horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else
        {
            if (horizontal > 0.0f)
            {
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
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
            Console.Write("Cambiando a p");
            animator.SetBool("attack", true);
            animator.Play("Ataque1");
            /*efectos.clip = Ataque1;
            efectos.Play();**/
        }

        animator.SetBool("attack", false);


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
}
