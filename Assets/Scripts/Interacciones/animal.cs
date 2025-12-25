using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class animal : MonoBehaviour
{
    //Canvas
    Canvas canvas_interaccion;
    public CanvasGroup grupo;
    //Textos
    [SerializeField] TMP_Text opcion_mala;
    [SerializeField] TMP_Text opcion_buena;
    //Variables
    public float targetAlpha = 1f;
    public float duration = 1f;
    private float startTime;

    void Start()
    {
        //Seteamos el canva
        canvas_interaccion = GetComponent<Canvas>();
        //Seteamos los textos
        opcion_buena.text = "Acariciar";
        opcion_mala.text = "Patear";
        Debug.Log("S'ha inicializado las opciones");

        if (canvasGroup == null)
            canvasGroup = GetComponent<CanvasGroup>();
        startTime = Time.time;
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
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //canvas_interaccion.alpha;
            //popupWindow.SetActive(true);
        }
    }
}
