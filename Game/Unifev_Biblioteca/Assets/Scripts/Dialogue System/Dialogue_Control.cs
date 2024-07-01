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
    private AudioSource Music_Source;
    private float music_volume;
    string[] dialogues,names;
    [SerializeField]
     Image D_Icon;
    private Sprite[] D_images;
    private AudioSource D_AudioSource;
    AudioClip[] Dub;
    int[]ImageSequences;
    int index;
    [HideInInspector]
    public bool Can_Move;

    private void Start()
    {
        Music_Source = GameObject.Find("Music_Player").GetComponent<AudioSource>();
       Can_Move = true;
        D_AudioSource = GetComponent<AudioSource>();
    }

    public void Play_Audio(AudioClip clip)
    {
        D_AudioSource.clip = clip;
        D_AudioSource.Play();
    }

    public void Start_Dialogue(string[] txts, string[] n, AudioClip[]D_voice,Sprite[] Icon,int[] Img_Sequence)
    {
        //Pass the information to the Dialogue Game Object
        index = 0;
        DObj.SetActive(true);
        dialogues = txts;
        names = n;
        D_images = Icon;
        ImageSequences = Img_Sequence;
        UI_name.text = names[index];
        D_Icon.sprite = D_images[ImageSequences[index]];
        Dub = D_voice;

        //Set the Music volume down
         music_volume = Music_Source.volume;
         Music_Source.volume -= 0.07f;

        //Play the audio and start the text
        Play_Audio(Dub[index]);
        StartCoroutine(LE());
        Can_Move = false;

    }

    // Letter enumetator
    IEnumerator LE()
    {
        foreach(char lt in dialogues[index].ToCharArray())
        {
            UI_txt.text += lt;
            yield return new WaitForSeconds(0.04f);
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
                UI_name.text = names[ImageSequences[index]];
                D_Icon.sprite = D_images[ImageSequences[index]];
                Play_Audio(Dub[index]);
                StartCoroutine(LE());
            }
            else
            {
                dialogues = null; 
                names = null;
                D_images = null;
                ImageSequences = null;
                index = 0;
                UI_txt.text = "";
                DObj.SetActive (false);
            
                Can_Move=true;
                Music_Source.volume = music_volume;
            }
        }
        else
        {
            StopAllCoroutines();
            UI_txt.text = null;
            UI_txt.text = dialogues[index];
        }
    }
}
