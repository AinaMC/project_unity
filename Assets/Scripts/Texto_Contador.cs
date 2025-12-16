using TMPro;
using UnityEngine;

public class Texto_Contador : MonoBehaviour
{
    [SerializeField] TMP_Text texto;
    int puntos_globales = 50;

    void Start()
    {
        //CambiarContador(0);
    }
   public void CambiarContador(int points)
    {        
        //Depende de que tengamos que hacer 
        puntos_globales = puntos_globales + points;
        texto.text = "Contador: " + puntos_globales;

        if (puntos_globales >= 100 )
        {
            puntos_globales = 100;
            texto.text = "Contador: " + puntos_globales;
        }
        else if (puntos_globales < 1)
        {
            puntos_globales = 1;
            texto.text = "Contador: " + puntos_globales;
        }


    }
    
    void Update()
    {
        
    }
}
