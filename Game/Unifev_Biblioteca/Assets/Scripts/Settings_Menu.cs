using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings_Menu : MonoBehaviour
{
    [SerializeField]
    private AudioSource AS_music,AS_dialogue;
    public GameObject Settings,IMGB;
    private bool active;

    private void Start()
    {
        active = false;
    }

    public void Music(float vol)
    {
        AS_music.volume = vol;
    }
    public void Dialogue(float vol)
    {
        AS_dialogue.volume = vol;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            active = !active;
            Settings.SetActive(active);
            IMGB.SetActive(!active);
            if(active)
            {
              Time.timeScale = 0f;
            }
            else 
            {
                Time.timeScale = 1f;
            }
        }
    }
}
