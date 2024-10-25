using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Off : MonoBehaviour
{
   [SerializeField]
   private GameObject Tutorial_UI;

    public void Turn_off_button()
    {
        Tutorial_UI.SetActive(false);
    }
}
