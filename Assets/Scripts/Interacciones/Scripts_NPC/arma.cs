using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class arma : MonoBehaviour
{
    //Textos
    [SerializeField] TMP_Text opcion_mala;
    [SerializeField] TMP_Text opcion_buena;
    //Centro Interacción
    public centro_interaccion centro;
    public WorldManagement control_mundo;

    public void texto()
    {
        //Seteamos los textos
        opcion_buena.text = "No cojer el arma";
        opcion_mala.text = "Quedarse el arma";
    }

    public void accion_buena()
    {
        //Debug.Log("Opcion Buena");
        control_mundo.recibir_puntos(2.5f);
    }
    public void accion_mala()
    {
        //Debug.Log("Opcion Mala");
        control_mundo.recibir_puntos(-2.5f);
    }
}
