using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photo : MonoBehaviour
{
    //Atributos.
    private Grave grave; //Puntero a la otra clase.

    //Constructor.
    private void Awake()
    {

    }

    //Métodos.


    //Método de tocamiento.
    private void OnTriggerEnter2D(Collider2D other)
    {
        this.grave = FindObjectOfType<Grave>();
        GameManager.current.OnPhoto();

        if (this.grave == null)
        {
            Debug.LogError("NO HAY TUMBA!");
        }

        this.grave.FotosRecogidas(); //La foto le manda una señal a tumba.
        this.gameObject.SetActive(false); //La foto desaparece al contacto.
    }
}
