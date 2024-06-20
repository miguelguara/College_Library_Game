using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meelee_Enemy : MonoBehaviour
{
    [Header("Configurações")]
    [SerializeField]
    private float Speed;
    public float attack_Range, follow_Range;
    public LayerMask Mask;
    private Rigidbody2D rb;
    private CapsuleCollider2D caps;
    private Animator anim;
    private Transform Player_Pos;
    [SerializeField]
    private Transform Attack_Point;
    bool  can_attack, Follow;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        caps = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        Player_Pos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Follow = Physics2D.OverlapCircle(transform.position,follow_Range,Mask);
        can_attack = Physics2D.OverlapCircle(transform.position, attack_Range, Mask);
        if(Follow && Speed>0)
        {
            Move(); 
        }
    }

    IEnumerator Attack()
    {
        can_attack = false;
        Speed = 0;
        anim.SetBool("Attack",true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("Attack",false);
        StartCoroutine(Attack());
    }
    
    void Move()
    {
        if(Player_Pos.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f,180f,0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        transform.position = Vector2.MoveTowards(transform.position,Player_Pos.position,Speed * Time.deltaTime);
        anim.SetFloat("Speed",Speed);
    }

}
