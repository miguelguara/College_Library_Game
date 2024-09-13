using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour
{
    [Header("Movment Config")]
    public float Velocity;
    public float Velocity_on_Air;
    public float Jump_Force;
    public int Life;
    public int DamegeOnEnemy;
    private Animator anim;
    private bool ground_Check;
    private Rigidbody2D rb;

    //The attack variables
    [Header("Radious of attack, enemys layer")]
    public float R_attack;
    public float Attack_Cooldown;
    private float Attack_timer;
    [SerializeField]
    private LayerMask Enemy_Mask;
    [SerializeField]
    private Transform Hit_point;

    //Life UI
    [SerializeField]
    private Text Life_UI;

    private Game_over GameOver;

    Vector3 dir;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();   
        GameOver = FindObjectOfType<Game_over>();
    }

    void Update()
    {
        dir = new Vector2 (Input.GetAxis("Horizontal"),0f);
        //set animations
        anim.SetFloat("Speed",dir.magnitude);
        anim.SetBool("Ground",ground_Check);
        anim.SetFloat("Air_Speed",rb.velocity.y);

        Attack_timer -= Time.deltaTime;

        if (ground_Check)
        {
            transform.position += dir * Velocity * Time.deltaTime;
        }
        else 
        {
            transform.position += dir * Velocity_on_Air * Time.deltaTime;
        }

        if(Attack_timer < -50)
        {
            Attack_timer = 0;
        }

        if(Input.GetMouseButtonDown(0) && Attack_timer <=0)
        {
            Attack();
            Attack_timer = Attack_Cooldown;
        }

        flip();
        Jump();
    }
 

    public void Take_Hit(int damage)
    {
        Life-= damage;
        Life_UI.text = Life.ToString();
        anim.SetTrigger("Hit");
        if(Life <= 0) { 
            Life_UI.text = 0.ToString();
            GameOver.GAME_OVER(); 
        }
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
  

    void Attack()
    {
        anim.SetTrigger("Attack");
        Collider2D[] Enemys_col = Physics2D.OverlapCircleAll(Hit_point.position, R_attack, Enemy_Mask); 
        foreach(Collider2D c in  Enemys_col)
        {
            if(c.tag == "Monster")
            {
              c.gameObject.GetComponent<Monster>().Die();
            }
            else if(c.tag == "MM")
            {
                c.gameObject.GetComponent<Meelee_Enemy>().Get_Hit(DamegeOnEnemy);
            }
          
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Hit_point.position, R_attack);
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
