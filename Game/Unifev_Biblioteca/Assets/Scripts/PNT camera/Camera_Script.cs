using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
   private Transform Cam_pos;
  
   public void Mov_cam(Transform pos)
    {
        Cam_pos = pos;
    } 

    void Update()
    {
        if(Cam_pos != null)
        {
            transform.position = Vector3.MoveTowards(transform.position,Cam_pos.position, 6f * Time.deltaTime);
            if (Vector3.Distance(transform.position, Cam_pos.position) < 0.01)
            {
                Cam_pos=null;
            }
        }
    }
}
