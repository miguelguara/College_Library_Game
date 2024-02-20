using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_NPC : MonoBehaviour
{
    [SerializeField]
    private Sprite Icon;
    public LayerMask mask;
    public float Radious;
    private Dialogue_Control DC;
    public string[] txt, names;
    bool Can_Talk;
    private move MV;
    void Start()
    {
        DC = FindObjectOfType<Dialogue_Control>();
        MV = FindAnyObjectByType<move>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D c = Physics2D.OverlapCircle(transform.position, Radious,mask);
        if (c != null)
        {
            Can_Talk = true;
        }
        else
        {
            Can_Talk = false;
        }

        if(Input.GetKeyDown(KeyCode.Space) && Can_Talk && MV.Can_play)
        {
            DC.Start_Dialogue(txt,names, Icon);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Radious);
    }
}
