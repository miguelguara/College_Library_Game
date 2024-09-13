using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note_Controller : MonoBehaviour
{   //the variables
    [SerializeField]
    GameObject note_GO;
    public Text tx;
    public AudioClip Paper_clip;

    private SFX_controller SFX;

    private void Start()
    {
        SFX = FindObjectOfType<SFX_controller>();
    }

    public void Note(string message)
    {
        note_GO.SetActive(true);
        tx.text = message;
        SFX.PlaySFX(Paper_clip);
    }
    public void clean_Note()
    {
        note_GO.SetActive(false);
        tx.text = null;
    }
}
