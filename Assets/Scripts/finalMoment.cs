using TMPro;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class finalMoment : MonoBehaviour
{
    //public GameObject gameOverUI;
    private bool theEnd = false;
    public centro_interaccion centro;
    [Header("Identificar mundo")]
    public int final_mundo;
    //Canvas
    [Header("Canvas")]
    public CanvasGroup grup;
    public Image barra_contador;

    [Header("Final")]
    public CanvasGroup fondo_grup;
    public Image fondo;

    [Header("Variables")]
    public float cuenta_atras = 100f;
    public float MAX_cuenta = 100f;
    public bool crono_activado;

    [Header("Textos")]
    [SerializeField] TMP_Text finalText;

    void Start()
    {
        barra_contador.fillAmount = cuenta_atras / MAX_cuenta;
        fondo_grup.alpha = Mathf.Lerp(0f, 0f, 5f);
        crono_activado = false;
        opacidad(0f);
    }
    //Aqui se reciben las nuevas opacidades
    public void opacidad(float nueva_opacidad)
    {
        grup.alpha = Mathf.Lerp(0f, nueva_opacidad, 5f);
    }
    void FixedUpdate()
    {
        Invoke("verContador", 1f);
    }

    void verContador()
    {
        if (crono_activado == true && cuenta_atras >= 0)
        {
            cuenta_atras = cuenta_atras - 0.1f;
            barra_contador.fillAmount = cuenta_atras / MAX_cuenta;
            finalText.text = "Fin";
        }
        else if (crono_activado == false && cuenta_atras > 0)
        {
            cuenta_atras = 100;
            opacidad(0f);
        }


        if (cuenta_atras <= 0 && !theEnd)
        {
            theEnd = true; //solo llamar una vez
            finJuego();
        }

    }
 
    public void final(int mundo)
    {
        final_mundo = mundo;
        crono_activado = true;
        opacidad(1f);

    }

    public void cancelar_final()
    {
        crono_activado = false;
        opacidad(0f);
    }


     void finJuego()
    {

        //Acaba utopico
        if (final_mundo == 1)
        {
            //fondo.Color(0f, 1f, 0f , 1f);
            Debug.Log("Fin Mundo Utopico");
            fondo_grup.alpha = Mathf.Lerp(0f, 1f, 5f);
            finalText.text = "Tu final ha sido bueno como tu, descansa";
        }
        //Acaba distopico
        else if (final_mundo == 2)
        {
            //fondo.Color(1f, 0f, 0f, 1f);
            Debug.Log("Fin Mundo Distopico");
            fondo_grup.alpha = Mathf.Lerp(0f, 1f, 5f);
            finalText.text = "No continues, has hecho suficiente daño";
        }
        centro.isGameFinished = true;
    }


}
