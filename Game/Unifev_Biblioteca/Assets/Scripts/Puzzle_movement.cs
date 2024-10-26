using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_movement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Animator anim;

    void Start()
    {
     anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
     Vector2 move_input = new Vector2 (Input.GetAxisRaw("Horizontal"),0f);
     transform.Translate(move_input * speed * Time.deltaTime, Space.World);
     flip(move_input);
    
    anim.SetFloat("Speed", move_input.magnitude);
    }
    
        void flip(Vector2 dir)
        {
            if (dir.x > 0)
            {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }

            else if (dir.x < 0)
            {
            transform.eulerAngles = Vector3.zero;
            }
        }

}
