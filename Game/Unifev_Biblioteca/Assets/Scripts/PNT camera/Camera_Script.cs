using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
   public Transform Cam_pos;
    Vector3 t;
   public void Mov_cam(Transform pos)
    {
        Cam_pos = pos;
    } 

    void Update()
    {
        
        Vector3.MoveTowards(transform.position,t, 6f * Time.deltaTime);
        
    }
}
