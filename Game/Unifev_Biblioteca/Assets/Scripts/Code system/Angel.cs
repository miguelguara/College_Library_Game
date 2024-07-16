using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angel : MonoBehaviour
{
    [SerializeField]
    private string Stone_name;
    private Angel_Controller AC;

    private void Start()
    {
        AC = FindAnyObjectByType<Angel_Controller>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == Stone_name)
        {
            AC.Right_Stone();
        }
    }
}
