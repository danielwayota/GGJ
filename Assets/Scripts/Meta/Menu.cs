using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    public GameObject credits;

    public void Play()
    {
        this.LoadLevel(SceneNames.GAME);
    }

    public void Credits()
    {
        this.menu.SetActive(false);
        credits.SetActive(true);

    }
    public void BackMenu()
    {
        this.menu.SetActive(true);
        credits.SetActive(false);

    }

    public void Exit()
    {
        Application.Quit();
    }


    private void LoadLevel(string levelname)
    {
        Loading.LoadScene(levelname);
    }
}
