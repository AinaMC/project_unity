using UnityEngine;


public class WorldManagement : MonoBehaviour
{
    //Variables
    //Enviar a script CONTADOR
    Texto_Contador texto_Contador;
    
    //Trobem el Contador
    void Start()
    {
        texto_Contador = GetComponent<Texto_Contador>();
        //Actualizamos
        recibir_puntos(0);
    }
    //Recibir cambios de puntos por interacción y los mandamos script CONTADOR
    public void recibir_puntos(int points)
    {
        texto_Contador.CambiarContador(points);
        Debug.Log("S'han enviat al Contador: " + points);
    }

    private void Update()
    {
        //Esquerra
        if(Input.GetMouseButton(0))
        {
            texto_Contador.CambiarContador(-1);

        }
        //Dreta
        if (Input.GetMouseButton(1))
        {
            texto_Contador.CambiarContador(1);
        }
    }
}