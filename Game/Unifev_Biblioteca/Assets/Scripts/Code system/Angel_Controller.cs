using UnityEngine;

public class Angel_Controller : MonoBehaviour
{
    private int count;
    [SerializeField]
    private GameObject Ring;
    public Transform Ring_pos;
   void Right_Stone()
    {
        count++;
        if(count == 2)
        {
            Instantiate(Ring,Ring_pos.position,Quaternion.identity);
        }
    }
}
