using TMPro;
using UnityEngine;
using UnityEngine.UI;
//Animales --> [+/- 10 puntos]
public class animal : MonoBehaviour
{
    //Textos
    [SerializeField] TMP_Text opcion_mala;
    [SerializeField] TMP_Text opcion_buena;
    //Centro Interacción
    public centro_interaccion centro;
    public WorldManagement control_mundo;

    void Start()
    {
        //Seteamos los textos
        opcion_buena.text = "Acariciar";
        opcion_mala.text = "Patear";
    }

    public void texto()
    {
        //Seteamos los textos
        opcion_buena.text = "Acariciar";
        opcion_mala.text = "Patear";
    }


    //Entrar en la zona
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player ha entrado en Zona");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player ha entrado en Zona");
            //OPACIDAD
            centro.opacidad(1f);
        }
    }
    //Permanecer en la zona
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey("l"))
            {
                Debug.Log("Opcion Mala");
                control_mundo.recibir_puntos(-10);
            }
        if (Input.GetKey("k"))
        {
            Debug.Log("Opcion Buena");
            control_mundo.recibir_puntos(10);
        }
        }

    }
    //Salir de la zona
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player ha salido de la Zona");
            //OPACIDAD
            centro.opacidad(0f);
        }
    }
}
