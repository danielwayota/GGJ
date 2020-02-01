using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : MonoBehaviour
{
    //Atributos.
    private const int FOTOS = 5;
    private int recogidas;

    //Constructor.
    private void Awake()
    {

    }

    //Métodos.
    public void FotosRecogidas()
    {
        this.recogidas++;
    }

    //Método que observa si hay tocamientos con la tumba.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.recogidas < FOTOS)
        {
            Debug.Log("Debes tener todas las fotos.");
        }
        else
        {
            Loading.LoadScene(SceneNames.FINAL);
        }
    }



}
