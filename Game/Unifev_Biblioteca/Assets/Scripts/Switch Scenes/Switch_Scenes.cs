using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class Switch_Scenes : MonoBehaviour
{
    [SerializeField]
    private string _scenesName;
    public float Raio;
    private bool Can;
    public GameObject UI;
    [SerializeField]
    LayerMask mask;

    private void Update()
    {
        Can = Physics2D.OverlapCircle(transform.position, Raio,mask);
        if (Can)
        {
            UI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(_scenesName);
            }
        }
        else
        {
            UI.gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Raio);
    }
}
