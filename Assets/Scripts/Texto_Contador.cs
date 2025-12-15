using UnityEngine;

public class Texto_Contador : MonoBehaviour
{
    private int puntos_globales = 50;


    void Start()
    {
    }
   public void CambiarContador(int points)
    {
        //Depende de que tengamos que hacer 
        puntos_globales = puntos_globales + points;
    }
    
    void Update()
    {
        
    }
}
