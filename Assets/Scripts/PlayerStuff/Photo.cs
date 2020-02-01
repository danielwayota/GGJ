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
        this.grave = FindObjectOfType<Grave>();
        if (this.grave == null)
        {
            Debug.LogError("NO HAY TUMBA!");
        }
    }

    //Métodos.


    //Método de tocamiento.
    private void OnTriggerEnter2D(Collider2D other)
    {
        this.grave.FotosRecogidas(); //La foto le manda una señal a tumba.
        this.gameObject.SetActive(false); //La foto desaparece al contacto.
    }
}
