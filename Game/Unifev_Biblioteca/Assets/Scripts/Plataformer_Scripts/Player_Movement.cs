using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("Movment Config")]
    public float Velocity;
    public float Velocity_on_Air;
    public float Jump_Force;
    private Animator anim;
    private bool ground_Check;
    private Rigidbody2D rb;
    Vector3 dir;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();   
    }

    void Update()
    {
        dir = new Vector2 (Input.GetAxisRaw("Horizontal"),0f);
        //set animations
        anim.SetFloat("Speed",dir.magnitude);
        anim.SetBool("Ground",ground_Check);
        anim.SetFloat("Air_Speed",rb.velocity.y);

        if(ground_Check)
        {
            transform.position += dir * Velocity * Time.deltaTime;
        }
        else
        {
            transform.position += dir * Velocity_on_Air * Time.deltaTime;
        }
        flip();
        Jump();
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && ground_Check)
        {
            rb.AddForce(Vector3.up * Jump_Force, ForceMode2D.Impulse);
        }
    }
    void flip()
    {
        if(dir.x > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }else if(dir.x < 0)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
     if(col.tag == "Ground")
        {
            ground_Check = true;
        }   
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Ground")
        {
            ground_Check = false;
        }
    }
}
