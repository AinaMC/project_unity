using UnityEngine;


public class WorldManagement : MonoBehaviour
{
    //Variables
    private int estado_mundo = 50;
    Texto_Contador mundo;

    //Trobem el Contador
    void Start()
    {
        mundo = GetComponent<Texto_Contador>();
        //Actualizamos
        recibir_puntos(estado_mundo);
    }

    private void Update()
    {
        //Esquerra
        if(Input.GetMouseButton(0))
        {
            recibir_puntos(-1);

        }
        //Dreta
        if (Input.GetMouseButton(1))
        {
            recibir_puntos(1);
        }
    }    
    //AQUI ENVIAR TODOS LOS PUNTOS DESDE CUALQUIER SCRIPT
    //Aquí llegaran los nuevos puntos de otros scripts y de aqui cambia el contador
    public void recibir_puntos(int points)
    {
        //int estado_Actual, int points
        mundo.CambiarContador(estado_mundo, points);
        Debug.Log("S'han enviat al Contador: " + points);

        estado_mundo = estado_mundo + points;

        if (estado_mundo >= 100)
        {
            estado_mundo = 100;
        }
        else if (estado_mundo <= 1)
        {
            estado_mundo = 1;
        }
    }

    public int estatus_mundo()
    {
        return estado_mundo;
    }
}