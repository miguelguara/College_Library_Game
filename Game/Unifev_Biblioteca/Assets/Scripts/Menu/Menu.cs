using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private Animator m_Animator;
    private bool is_clicked = false;

    public void Start_Button()
    {
        if (!is_clicked)
        {
            is_clicked = true;
            StartCoroutine(S_game());
        }
    }

    public IEnumerator S_game()
    {
        m_Animator.SetBool("Transition",true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
}
