using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class soldado_quieto : MonoBehaviour
{
    //Textos
    [SerializeField] TMP_Text opcion_mala;
    [SerializeField] TMP_Text opcion_buena;
    //Centro Interacción
    public centro_interaccion centro;
    public WorldManagement control_mundo;
    public Animator anim;

    public void texto()
    {
        //Seteamos los textos
        opcion_buena.text = "Saludar";
        opcion_mala.text = "Pegarle";
    }

    public void accion_buena()
    {
        //Debug.Log("Opcion Buena");
        control_mundo.recibir_puntos(3.5f);
    }
    public void accion_mala()
    {
        anim.SetTrigger("mala_accion");
        //Debug.Log("Opcion Mala");
        control_mundo.recibir_puntos(-3.5f);
    }
}
