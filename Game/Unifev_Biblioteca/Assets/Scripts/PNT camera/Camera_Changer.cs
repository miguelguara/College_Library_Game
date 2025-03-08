using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Camera_Changer : MonoBehaviour
{
    private Camera_Script CS;
    [SerializeField] private Transform Move_point;
    [SerializeField] private UnityEvent Setas;

    private void Start()
    {
        CS = FindObjectOfType<Camera_Script>();
    }

    private void OnTriggerEnter2D(Collider2D co)
    {
        if(co.tag == "Player")
        {
           CS.Mov_cam(Move_point);
            Setas.Invoke();
        }
    }
}
