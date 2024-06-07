using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform[] way_Points;
    int index;
    public Transform atack_point;
    public float vel;
    public float atackradious;
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField]
    private LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        index = 0;
    }

    void Update()
    {
        if(index == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, way_Points[index].position, vel * Time.deltaTime);
            look_Point(way_Points[index]);
            if(Vector2.Distance(transform.position, way_Points[index].position) < 0.5f)
            {
                index = 1;
            }
        }
        else if (index == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, way_Points[index].position, vel * Time.deltaTime);
            look_Point(way_Points[index]);
            if (Vector2.Distance(transform.position, way_Points[index].position) < 0.5f)
            {
                index = 0;
            }
        }

    }

    IEnumerator Attack()
    {
        vel = 0;
        anim.SetBool("Attack",true);
        yield return new WaitForSeconds(1.05f);
        anim.SetBool("Attack",false);
        vel = 4;
    }
    

    void look_Point(Transform TR)
    {
        if (TR.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f,180f,0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            StartCoroutine(Attack());
        }
    }

    public void Dano()
    {
        Collider2D c = Physics2D.OverlapCircle(atack_point.position, atackradious, mask);
        if(c != null)
        {
            c.gameObject.GetComponent<Player_Movement>();
        }
    }
}
