using UnityEngine;

public class Finishing_level : MonoBehaviour
{
    //Finishing level UI;
    public GameObject GameObject;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            GameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
