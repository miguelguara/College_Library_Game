using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private Note_Controller controller;
    [Header("Escreva a mensagem:")]
    public string MS;
    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<Note_Controller>();
    }

    private void OnMouseDown()
    {
        controller.Note(MS);
    }
}
