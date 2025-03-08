using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_controler : MonoBehaviour
{
    public GameObject SetaEsquerda,SetaDireita;

    private void Start()
    {
        PiscarDireira();
    }

    public void PiscarDireira() 
    {
        StopAllCoroutines();
        StartCoroutine(AtivarSetaDireita());
        SetaEsquerda.SetActive(false);
    }

    public void PiscarEsquerda()
    {
        StopAllCoroutines();
        StartCoroutine(AtivarSetaEsquerda());
        SetaDireita.SetActive(false);
    }

    public void PiscarAmbas()
    {
        StopAllCoroutines();
        StartCoroutine(AtivarSetaEsquerda());
        StartCoroutine(AtivarSetaDireita());
    }

    IEnumerator AtivarSetaEsquerda()
    {
        SetaEsquerda.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        SetaEsquerda.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(AtivarSetaEsquerda());
    }


    IEnumerator AtivarSetaDireita()
    {
        SetaDireita.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        SetaDireita.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(AtivarSetaDireita());
    }
}
