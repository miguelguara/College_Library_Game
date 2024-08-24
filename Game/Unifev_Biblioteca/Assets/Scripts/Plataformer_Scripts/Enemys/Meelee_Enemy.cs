using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meelee_Enemy : MonoBehaviour
{
    [Header("Configurações")]
    //enemy configs
    public int Life;
    [SerializeField]
    private float Speed;
    public float attack_Range, follow_Range;
    public LayerMask Mask;
    private Animator anim;
    private Transform Player_Pos;
    [SerializeField]
    private Transform Attack_Point;
    bool Follow;
    private SpriteRenderer SR;
    //detect the trigger;
     public Collision_ME CME;

    // swich the collors
    public Color[] c;


    void Start()
    {
        CME = GetComponentInChildren<Collision_ME>();
        anim = GetComponent<Animator>();
        Player_Pos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        SR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Follow = Physics2D.OverlapCircle(transform.position,follow_Range,Mask);
        if(Follow && Speed>0)
        {
            Move();
            anim.SetBool("Speed", true);
        }
        else
        {
            anim.SetBool("Speed", false);
        }

        if (CME.Can_attack == true)
        {
            StartCoroutine(Attack());
        }
     
    }

    IEnumerator Attack()
    {
        CME.Can_attack = false;
        Speed = 0;
        anim.SetBool("Attack",true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("Attack",false);
        yield return new WaitForSeconds(1f);
        StartCoroutine(Attack());
    }

    public void FollowAgain()
    {

        StopAllCoroutines();
        StartCoroutine(FA());
    }
    public IEnumerator FA()
    {
        anim.SetBool("Attack",false);
        yield return new WaitForSeconds(2f);
        anim.SetBool("Speed", true);
        Speed = 4;
    }

    public void Get_Hit(int DMG)
    {
        StartCoroutine(GetHit(DMG));
    }

    IEnumerator GetHit(int dmg)
    {
        anim.SetBool("Attack", false);
        anim.SetTrigger("Hit");
        SR.color = c[0];
        yield return new WaitForSeconds(0.2f);
        SR.color = c[1];
        Life-=dmg;
        if(Life <= 0)
        {
            Destroy(gameObject, 1f);
        }
        yield return new WaitForSeconds(1.6f);
        if (Vector2.Distance(transform.position, Player_Pos.position) < 2f)
        {
            StartCoroutine(Attack());
        }
    }

    void Damege()
    {
        Collider2D c = Physics2D.OverlapCircle(Attack_Point.position, attack_Range, Mask);
        if(c != null)
        {
            c.gameObject.GetComponent<Player_Movement>().Take_Hit(2);
        }
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
        Vector3 follow_Pos = new Vector3(Player_Pos.position.x,transform.position.y,0f);
        transform.position = Vector2.MoveTowards(transform.position,follow_Pos,Speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Attack_Point.position,attack_Range);
        Gizmos.DrawWireSphere(transform.position, follow_Range);
    }
}
