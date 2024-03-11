using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note_Controller : MonoBehaviour
{   //the variables
    [SerializeField]
    GameObject note_GO;
    public Text tx;

    public void Note(string message)
    {
        note_GO.SetActive(true);
        tx.text = message;
    }
    public void clean_Note()
    {
        note_GO.SetActive(false);
        tx.text = null;
    }
}
