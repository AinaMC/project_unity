using UnityEngine;

//Utopia = 100
//Distopia = 1
public class WorldManagement : MonoBehaviour
{
    //Variables
    private float estado_mundo = 50f;

    //Trobem el Contador
    void Start()
    {
        //Actualizamos
        recibir_puntos(0);
    }

    //AQUI ENVIAR TODOS LOS PUNTOS DESDE CUALQUIER SCRIPT
    //Aquí llegaran los nuevos puntos de otros scripts y de aqui cambia el contador
    public void recibir_puntos(float points)
    {
        //int estado_Actual, int points
        Debug.Log("S'han enviat al Contador: " + points);

        estado_mundo = estado_mundo + points;

        if (estado_mundo >= 100f)
        {
            estado_mundo = 100f;
        }
        else if (estado_mundo <= 0f)
        {
            estado_mundo = 0f;
        }
    }

    public float estatus_mundo()
    {
        return estado_mundo;
    }
}