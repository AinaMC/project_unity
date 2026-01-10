

using System.Reflection;
using UnityEngine;
using UnityEngine.UI;


public class finalMoment : MonoBehaviour
{
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
    public int cuenta_atras = 1000;
    public int MAX_cuenta = 1000;
    public bool crono_activado;
    
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
        if (crono_activado == true)
        {
            Invoke("restar_contador", 5f);

            if (cuenta_atras == 0)
            {
                finJuego();
            }
        }
        else
        {
            cuenta_atras = 1000;
            opacidad(0f);
        }
        
    }
    void restar_contador()
    {
        cuenta_atras -= 1;
        barra_contador.fillAmount = cuenta_atras / MAX_cuenta;
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
    private void finJuego()
    {
        //Acaba utopico
        if (final_mundo == 1)
        {
            //fondo.Color(0f, 1f, 0f , 1f);
            Debug.Log("Fin Mundo Utopico");
            fondo_grup.alpha = Mathf.Lerp(0f, 1f, 5f);
        }
        //Acaba distopico
        else if (final_mundo == 2)
        {
            //fondo.Color(1f, 0f, 0f, 1f);
            Debug.Log("Fin Mundo Distopico");
            fondo_grup.alpha = Mathf.Lerp(0f, 1f, 5f);
        }
        Debug.Log("Fin Mundo");
    }

}
