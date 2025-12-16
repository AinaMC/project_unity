using System.Diagnostics;
using UnityEngine;

public class Tienda_Collider : MonoBehaviour
{
    WorldManagement world;
    Tienda_Collider tienda;
    Texto_Contador texto_Contador;
    //private int puntos_tienda = 10; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tienda = GetComponent<Tienda_Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter (Collision collision)
    {
        
        world.recibir_puntos(10);
        texto_Contador.CambiarContador(10);

    }
    /*void OnTriggerEnter(Collision other)
    {
        world.recibir_puntos(10);

    }*/
}
