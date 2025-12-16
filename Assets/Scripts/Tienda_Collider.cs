using System.Diagnostics;
using UnityEngine;

public class Tienda_Collider : MonoBehaviour
{
    public WorldManagement world;

    //private int puntos_tienda = 10; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // world = GetComponent<WorldManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Debug.Log("El jugador ha entrado en el trigger.");
            world.recibir_puntos(10);

        }
    }
}
