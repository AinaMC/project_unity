using TMPro;
using UnityEngine;
using UnityEngine.UI;
//Comerciantes --> [+15 /-20 puntos]
public class comerciante : MonoBehaviour
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
        opcion_buena.text = "Reirse de su broma";
        opcion_mala.text = "Pegarle con un palo";
    }

    public void accion_buena()
    {
        //Debug.Log("Opcion Buena");
        control_mundo.recibir_puntos(1.5f);
    }
    public void accion_mala()
    {
         //Debug.Log("Opcion Mala");
         control_mundo.recibir_puntos(-2.0f);
    }


}
