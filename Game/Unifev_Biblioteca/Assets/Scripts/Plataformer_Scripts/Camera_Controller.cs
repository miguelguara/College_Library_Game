using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    private Transform Player_pos;
    
    //set the velocity of the camera by the distance
    [SerializeField]
    private float FarSpeed, CloseSpeed;


    void Start()
    {
        Player_pos = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(Player_pos.position.x,transform.position.y,transform.position.z);
     if(Vector3.Distance(transform.position, Player_pos.position) > 7f)
        {
            transform.position = Vector3.MoveTowards(transform.position,pos, FarSpeed * Time.deltaTime);
        }
     else if(Vector3.Distance(transform.position, Player_pos.position) < 7f)
        {

            transform.position = Vector3.MoveTowards(transform.position, pos, CloseSpeed * Time.deltaTime);
        }
    }
}
