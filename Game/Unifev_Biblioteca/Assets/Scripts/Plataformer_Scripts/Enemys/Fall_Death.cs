using UnityEngine;

public class Fall_Death : MonoBehaviour
{
    private Player_Movement Player;
    private void Start()
    {
       Player = FindObjectOfType<Player_Movement>();
    }

    private void OnTriggerEnter2D(Collider2D co)
    {
       if(co.tag == "Player")
        {
            Player.Take_Hit(10);
        } 
    }
}
