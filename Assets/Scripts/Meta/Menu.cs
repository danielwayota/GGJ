using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {

    }

    public void Credits()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }


    private void LoadLevel(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }
}
