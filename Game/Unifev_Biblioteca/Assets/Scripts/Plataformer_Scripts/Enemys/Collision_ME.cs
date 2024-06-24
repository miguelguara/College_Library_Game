using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Collision_ME : MonoBehaviour
{
    [SerializeField]
    UnityEvent Action;
    [HideInInspector]
    public bool Can_attack;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            Can_attack = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {

        if (col.tag == "Player")
        {
            Can_attack = false;
            Action.Invoke();
        }
    }
}
