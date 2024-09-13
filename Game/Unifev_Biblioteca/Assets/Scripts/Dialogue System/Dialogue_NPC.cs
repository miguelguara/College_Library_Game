using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_NPC : MonoBehaviour
{
    public LayerMask mask;
    private Dialogue_Control DC;
    [Header("Dialogue config.")]
    [SerializeField]
    private Sprite[] Icons;
    public float Radious;
    public string[] names,txt;
    public int[] IMG_indexes;
    public AudioClip[] Dialogue_Voices; 
    bool Can_Talk;
    private move MV;

    //interact UI element
    [SerializeField]
    private GameObject UIobj;

    void Start()
    {
        DC = FindObjectOfType<Dialogue_Control>();
        MV = FindAnyObjectByType<move>();
    }

    // Update is called once per frame
    void Update()
    {
       Can_Talk = Physics2D.OverlapCircle(transform.position,Radious,mask);

        //Active the UI element, that was the only way that work
        UIobj.SetActive(Can_Talk);

        //Check if the player is talkable
        if (Input.GetKeyDown(KeyCode.E) && Can_Talk && DC.Can_Move)
        {
          DC.Start_Dialogue(txt, names,Dialogue_Voices,Icons,IMG_indexes);
        }
        else if(Input.GetKeyDown(KeyCode.E) && Can_Talk && !DC.Can_Move)
        {
            DC.NextDialogue();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Radious);
    }
}
