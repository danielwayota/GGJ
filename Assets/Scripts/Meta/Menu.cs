using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    public GameObject credits;

    public AudioSource blup;

    public void Play()
    {
        this.blup.Play();

        StartCoroutine(this.LoadLevel(SceneNames.GAME));
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

    private IEnumerator LoadLevel(string levelname)
    {
        yield return new WaitForSeconds(0.5f);

        Loading.LoadScene(levelname);
    }
}
