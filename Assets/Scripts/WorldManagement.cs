using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WorldManagement : MonoBehaviour
{
    //Variables
    Texto_Contador texto_Contador;
    public Text textoContador;

    
    //Trobem el Contador
    void Start()
    {
        //Actualizamos

        Debug.Log("se ha acrualizado");

    }
    //Recibir cambios de puntos por interacción
    void recibir_puntos(int points)
    {
        texto_Contador.CambiarContador(points);
    }
}