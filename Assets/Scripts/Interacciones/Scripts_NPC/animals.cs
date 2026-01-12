using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//Comerciantes --> [+15 /-20 puntos]
public class animals : MonoBehaviour
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
        buena.text = "Acariciar";
        mala.text = "Pegar";
    }

    public void accion_buena(Animator anim)

    {
        //Debug.Log("Opcion Buena");
        control_mundo.recibir_puntos(10.5f);
        anim.SetTrigger("acariciar");
    }
    public void accion_mala(Animator anim)
    {
        //Debug.Log("Opcion Mala");
        anim.SetTrigger("pegar");
       
        control_mundo.recibir_puntos(-10.5f);
    }
}