using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public static string nextScene;

    // =============================================
    public static void LoadScene(string name)
    {
        nextScene = name;
        SceneManager.LoadScene(SceneNames.LOADING);
    }

    // =============================================
    void Start()
    {
        StartCoroutine(this.LoadNext());
    }

    // =============================================
    IEnumerator LoadNext()
    {
        yield return new WaitForSeconds(1f);
        var process = SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Single);

        while (!process.isDone)
        {
            yield return null;
        }
    }
}

