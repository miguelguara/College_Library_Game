using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Code_Controler : MonoBehaviour
{
    public GameObject Code_Obj;
    int N1, N2, N3;
    public Text Ntx1, Ntx2,Ntx3;
    //Just to play the SFX
    private SFX_controller SFX;
    [SerializeField]
    private AudioClip Click_audio;

    private void Start()
    {
        SFX = FindObjectOfType<SFX_controller>();
    }


    public bool verificar_Code(int c1,int c2, int c3,bool Check)
    {
        if(c1 == N1 && c2 == N2 && c3 == N3) 
        {
            Check = true; 
            Code_Obj.SetActive(false);
        }
        return Check;
    }

    public void ativar_Code()
    {
        Code_Obj.SetActive(true);
        N1 = 0; N2 = 0;N3 = 0;
        Ntx1.text = N1.ToString();
        Ntx2.text = N2.ToString();
        Ntx3.text = N3.ToString();
    }

    public void N1_Cima()
    {
        SFX.PlaySFX(Click_audio);
        N1++;
        Ntx1.text = N1.ToString();
        if(N1 > 9)
        {
            N1 = 0;
            Ntx1.text = N1.ToString();
        }
    }

    public void N1_Baixo()
    {
        SFX.PlaySFX(Click_audio);
        N1--;
        Ntx1.text = N1.ToString();
        if (N1 < 0)
        {
            N1 = 9;
            Ntx1.text = N1.ToString();
        }
    }

    public void N2_Cima()
    {
        SFX.PlaySFX(Click_audio);
        N2++;
        Ntx2.text = N2.ToString();
        if (N2 > 9)
        {
            N2 = 0;
            Ntx1.text = N1.ToString();
        }
    }

    public void N2_Baixo()
    {
        SFX.PlaySFX(Click_audio);
        N2--;
        Ntx2.text = N2.ToString();
        if (N2 < 0)
        {
            N2 = 9;
            Ntx2.text = N2.ToString();
        }
    }

    public void N3_Cima()
    {
        SFX.PlaySFX(Click_audio);
        N3++;
        Ntx3.text = N3.ToString();
        if (N3 > 9)
        {
            N3 = 0;
            Ntx3.text = N3.ToString();
        }
    }

    public void N3_Baixo()
    {
        SFX.PlaySFX(Click_audio);
        N3--;
        Ntx3.text = N3.ToString();
        if (N3 < 0)
        {
            N3 = 9;
            Ntx3.text = N3.ToString();
        }
    }

    public void Desativar_Puzzle()
    {
       Code_Obj.SetActive(false);
    }
}
