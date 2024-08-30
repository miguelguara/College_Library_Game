using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit_livro : MonoBehaviour
{
    [SerializeField]
    private float Raio;
    // the UI objects!
    public GameObject obj,obj2;
    [SerializeField]
    private LayerMask lM;


    // Update is called once per frame
    void Update()
    {
        bool Is_on = Physics2D.OverlapCircle(transform.position, Raio,lM); 
        if (Is_on) 
        {
            obj.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                obj2.SetActive(true);
            }
        }
        else
        {
            obj.SetActive(false);
        }
    }
    //To load when the kig dont want to play anymore
    public void Quit_Fase()
    {
        SceneManager.LoadScene(0);
    }
    //Set off the UI of the quit UI
    public void Set_OFF()
    {
        obj2.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Raio);
    }
}
