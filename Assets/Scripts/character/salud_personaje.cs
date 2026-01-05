using TMPro;
using UnityEngine;

public class salud_personaje : MonoBehaviour
{
    [SerializeField] TMP_Text vida;
    //Escribir como depende del mundo se cura mas o menos
    
    int puntos_salud = 25;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        vida.text = "Vida: " + puntos_salud;
        Debug.Log("S'ha inicializado la vida");
        
    }

    public void curarse(int pts)
    {
        //Depende de que tengamos que hacer 
        puntos_salud = puntos_salud + pts;
        vida.text = "Contador: " + puntos_salud;

        if (puntos_salud >= 50)
        {
            puntos_salud = 50;
            vida.text = "Contador: " + puntos_salud;
        }
        else if (puntos_salud < 1)
        {
            puntos_salud = 1;
            vida.text = "Contador: " + puntos_salud;
        }

    }
}
