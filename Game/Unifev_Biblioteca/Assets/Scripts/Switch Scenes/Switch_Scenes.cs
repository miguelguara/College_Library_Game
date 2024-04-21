using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class Switch_Scenes : MonoBehaviour
{
    [SerializeField]
    string _scenesName;
    public float Raio;
    private bool Can;
    public GameObject UI;
    public Text UI_Scene_Name;
    [SerializeField]
    LayerMask mask;

    private void Start()
    {
      UI_Scene_Name.text = "Precione 'E' para entrar na fase: "+_scenesName;
    }
    private void Update()
    {
        Can = Physics2D.OverlapCircle(transform.position, Raio,mask);
        if (Can)
        {
            UI_Scene_Name.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(_scenesName);
            }
        }
        else
        {
            UI_Scene_Name.gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Raio);
    }
}
