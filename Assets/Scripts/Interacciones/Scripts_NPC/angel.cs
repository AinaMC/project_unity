using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class angel : MonoBehaviour
{
    //Textos
    [SerializeField] TMP_Text mala;
    [SerializeField] TMP_Text buena;
    //Centro Interacción
    public centro_interaccion centro;
    public WorldManagement control_mundo;


    public void texto()
    {
        //Seteamos los textos
        buena.text = "Hacer una plegaria";
        mala.text = "Ignorar";
    }

    public void accion_buena()

    {
        //Debug.Log("Opcion Buena");
        control_mundo.recibir_puntos(50f);
    }
    public void accion_mala()
    {
        //Debug.Log("Opcion Mala");
        control_mundo.recibir_puntos(0f);
    }
}
