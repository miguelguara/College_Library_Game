using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField]
    float Speed;
    public bool Can_play;
    // Start is called before the first frame update
    void Start()
    {
     Can_play = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Can_play)
        {
            Vector3 dr = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f).normalized;
            transform.Translate(dr * Speed * Time.deltaTime, Space.Self);
        }
    }
}
