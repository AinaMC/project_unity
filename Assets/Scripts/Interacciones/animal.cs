using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class animal : MonoBehaviour
{
    //Textos
    [SerializeField] TMP_Text opcion_mala;
    [SerializeField] TMP_Text opcion_buena;


    void Start()
    {
        //Seteamos los textos
        opcion_buena.text = "Acariciar";
        opcion_mala.text = "Patear";
    }

    void Update()
    {    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //canvas_interaccion.alpha;
            //popupWindow.SetActive(true);
        }
    }
}
