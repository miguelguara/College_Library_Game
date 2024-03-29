using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Dialogue_Control : MonoBehaviour
{ 
    public Text UI_txt,UI_name;
    [SerializeField]
    GameObject DObj;
    string[] dialogues,names;
    [SerializeField]
    Image D_Icon;
    private move MV;
    private AudioSource D_AudioSource;
    AudioClip[] Dub;
    int index;

    private void Start()
    {
        MV = FindObjectOfType<move>();
        D_AudioSource = GetComponent<AudioSource>();
    }

    public void Play_Audio(AudioClip clip)
    {
        D_AudioSource.clip = clip;
        D_AudioSource.Play();
    }

    public void Start_Dialogue(string[] txts, string[] n, AudioClip[]D_voice,Sprite Icon)
    {
        //Pass the information to the Dialogue Game Object
        index = 0;
        DObj.SetActive(true);
        dialogues = txts;
        names = n;
        D_Icon.sprite = Icon;
        UI_name.text = names[index];
        Dub = D_voice;
        //Play the audio and start the text
        Play_Audio(Dub[index]);
        StartCoroutine(LE());
        if(MV != null)
        {
            MV.Can_play = false;
        }

    }

    // Letter enumetator
    IEnumerator LE()
    {
        foreach(char lt in dialogues[index].ToCharArray())
        {
            UI_txt.text += lt;
            yield return new WaitForSeconds(0.1f);
        }
    }


  public void NextDialogue()
    {
        if(UI_txt.text == dialogues[index])
        {
            if (index < dialogues.Length - 1)
            {
                UI_txt.text = "";
                UI_name.text = "";
                index++;
                D_AudioSource.Stop();
                UI_name.text = names[index];
                Play_Audio(Dub[index]);
                StartCoroutine(LE());
            }
            else
            {
                dialogues = null; 
                names = null;
                index = 0;
                UI_txt.text = "";
                DObj.SetActive (false);
                if(MV != null)
                {
                    MV.Can_play = true;
                }
            }
        }
    }
}
