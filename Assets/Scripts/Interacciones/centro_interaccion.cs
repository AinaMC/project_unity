using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//El objetivo de este script es:
// 1 - RECIBIR TEXTOS de las opciones de interacción de los diferentes colliders
// 2 - AJUSTAR OPACIDAD depeniendo si entra o sale del collider del obj
public class centro_interaccion : MonoBehaviour
{
    //Canvas
    //public Canvas canvas_interaccion;
    public CanvasGroup grup;
    //Textos
    [SerializeField] TMP_Text opcion_mala;
    [SerializeField] TMP_Text opcion_buena;


    void Start()
    {
        //Seteamos el canva
        //canvas_interaccion = GetComponent<Canvas>();
        grup = GetComponent<CanvasGroup>();
        //Seteamos los textos
        text_editor();
        opacidad(0f);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Time.time - startTime < duration)
        //{
        //    float t = (Time.time - startTime) / duration;
        //    canvasGroup.alpha = Mathf.Lerp(0f, targetAlpha, t);
        //}
        //else
        //{
        //    canvasGroup.alpha = targetAlpha;
        //}
    }

    //Tocar los Textos
    public void text_editor()
    {
        opcion_buena.text = "Texto Bueno";
        opcion_mala.text = "Texto Malo";
        Debug.Log("Interacciones actualizadas");
    }

    //Aqui se reciben las nuevas opacidades
    public void opacidad(float nueva_opacidad)
    {
        //float t = (Time.time - startTime) / duration;
        //canvasGroup.alpha = Mathf.Lerp(0f, targetAlpha, t);
        grup.alpha = Mathf.Lerp(0f, nueva_opacidad, 5f);
    }
}
