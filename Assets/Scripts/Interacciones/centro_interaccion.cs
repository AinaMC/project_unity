using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//El objetivo de este script es:
// AJUSTAR OPACIDAD depeniendo si entra o sale del collider del obj
public class centro_interaccion : MonoBehaviour
{
    //Canvas
    public CanvasGroup grup;
    //Textos
    [SerializeField] TMP_Text opcion_mala;
    [SerializeField] TMP_Text opcion_buena;

    void Start()
    {
        //Seteamos los textos
        opcion_buena.text = "Utopia";
        opcion_mala.text = "Distopia";
        //Seteamos el canva
        grup = GetComponent<CanvasGroup>();
        //Seteamos  opacidad
        opacidad(0f);
    }


    //Aqui se reciben las nuevas opacidades
    public void opacidad(float nueva_opacidad)
    {
        grup.alpha = Mathf.Lerp(0f, nueva_opacidad, 5f);
    }
}
