using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_controller : MonoBehaviour
{
    [SerializeField]
    private AudioSource AS;

    public void PlaySFX(AudioClip SFX)
    {
        AS.clip = SFX;
        AS.Play();
    }
}
