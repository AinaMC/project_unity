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


    void Start()
    {
        //Seteamos el canva
        grup = GetComponent<CanvasGroup>();
        //Seteamos  opacidad
        opacidad(0f);
    }


    //Aqui se reciben las nuevas opacidades
    public void opacidad(float nueva_opacidad)
    {
        //float t = (Time.time - startTime) / duration;
        //canvasGroup.alpha = Mathf.Lerp(0f, targetAlpha, t);
        grup.alpha = Mathf.Lerp(0f, nueva_opacidad, 5f);
    }
}
