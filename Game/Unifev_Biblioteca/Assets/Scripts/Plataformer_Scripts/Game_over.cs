using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_over : MonoBehaviour
{
    //The UI object
    public GameObject GO;

    public void GAME_OVER()
    {
        GO.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Back_to_library()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }

}
