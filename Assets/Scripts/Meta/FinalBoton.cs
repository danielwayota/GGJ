using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoton : MonoBehaviour
{
    public GameObject menu;

    public void BackMenu()
    {
        Loading.LoadScene(SceneNames.MENU);

    }
}
