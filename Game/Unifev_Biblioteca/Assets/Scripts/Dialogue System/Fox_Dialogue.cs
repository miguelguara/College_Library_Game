using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox_Dialogue : MonoBehaviour
{
    //Call the dialogue control
    private Dialogue_Control DC;
    private bool Ring;

    // The radious and LayerMask
    [Header("Raio do Dialogo e Layermask")]
    [SerializeField] float Radius;
    [SerializeField] private LayerMask Mask;

    // The first dialogue
    [Header("Dialogo 1")]
    [SerializeField] private string[] names;
    [SerializeField] private string[] Dialogues;
    [SerializeField] private Sprite[] DialogueImg;
    [SerializeField] private int[] DialogueNum;
    [SerializeField] private AudioClip[] DialogueClip;

    [Header("Dialogo 2")]
    [SerializeField] private string[] names2;
    [SerializeField] private string[] Dialogues2;
    [SerializeField] private Sprite[] DialogueImg2;
    [SerializeField] private int[] DialogueNum2;
    [SerializeField] private AudioClip[] DialogueClip2;

    //interact UI element
    [SerializeField]
    private GameObject UI_Interactive;

    void Start()
    {
     Ring = false;
     DC = FindObjectOfType<Dialogue_Control>();
    }

    private void Update()
    {
        bool Can_talk = Physics2D.OverlapCircle(transform.position, Radius,Mask);

        //Active the UI element, that was the only way that work
        if (Can_talk) { UI_Interactive.SetActive(true); }
        else { UI_Interactive.SetActive(false); }

        if (Can_talk) 
        {
            //Start the Dialogue if you didn't get the ring
            if (Input.GetKeyDown(KeyCode.E) && DC.Can_Move && !Ring) 
            { 
            DC.Start_Dialogue(Dialogues,names,DialogueClip,DialogueImg,DialogueNum);
            }
            //Start the dialogue if you have the ring
            else if (Input.GetKeyDown(KeyCode.E) && DC.Can_Move && Ring)
            {
             DC.Start_Dialogue(Dialogues2,names2, DialogueClip2, DialogueImg2, DialogueNum2);
            }
            //Jump the dialogue
            else if(Input.GetKeyDown(KeyCode.Space) && !DC.Can_Move) 
            {
                DC.NextDialogue();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
     if(c.tag == "Ring")
        {
            Destroy(c.gameObject);
            Ring = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
