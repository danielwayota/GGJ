﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    //Atributos.




    //Constructor.


    //Métodos.

    //Método al tocarse sensualmente.
    private void OnTriggerEnter2D(Collider2D other)
    {
        var moco = other.gameObject.GetComponent<Moco>(); //Salta al tocarse "SOLAMENTE" con el moco.
        moco.Die(); //El moco desaparece al tocar los pinchos.
    }
}
