using System.Collections;
using UnityEngine;
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
    private Animator anim;
    private bool click_Again;

    private void Start()
    {
        anim = GameObject.Find("Transition").GetComponent<Animator>();
        click_Again = true;
    }

    private void Update()
    {
        Can = Physics2D.OverlapCircle(transform.position, Raio,mask);
        if (Can)
        {
            if(click_Again)
            {
                UI.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    StartCoroutine(Switch());
                    click_Again=false;
                }
            }
        }
        else
        {
            UI.gameObject.SetActive(false);
        }
    }

    IEnumerator Switch()
    {
        UI.SetActive(false);
        anim.SetBool("Transition",true);
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(_scenesName);

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Raio);
    }
}
