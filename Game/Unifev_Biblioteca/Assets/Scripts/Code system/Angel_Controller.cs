using UnityEngine;

public class Angel_Controller : MonoBehaviour
{
    private int count;
    [SerializeField]
    private GameObject Ring;

    //Switch the sprite of the chest!
    [SerializeField]
    private Sprite Spr;
    [SerializeField]
    private SpriteRenderer Sr;
    public Transform Ring_pos;
   public void Right_Stone()
    {
        count++;
        if(count == 2)
        {
            Instantiate(Ring,Ring_pos.position,Quaternion.identity);
            Sr.sprite = Spr;
        }
    }
}
