
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
        mala.text = "Patear";
    }

    public void accion_buena()
    {
        //Debug.Log("Opcion Buena");
        control_mundo.recibir_puntos(10f);
    }
    public void accion_mala()
    {
        //Debug.Log("Opcion Mala");
        control_mundo.recibir_puntos(-10f);
    }
}