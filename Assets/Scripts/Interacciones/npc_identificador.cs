
using UnityEngine;

public class npc_identificador : MonoBehaviour
{
    public GameObject NPC_actual;
    //Centro Interacción
    public centro_interaccion centro;
    public animals a;
    public comerciante c;

    //Entrar en la zona
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player ha entrado en Zona");
            centro.opacidad(1f);
            if (NPC_actual.CompareTag("Animal"))
            {
                a.texto();
                Debug.Log("NPC ANIMAL");
            }
            if (NPC_actual.CompareTag("Comerciante"))
            {
                c.texto();
                Debug.Log("NPC COMERCIANTE");
            }
  
        }
    }
    //Permanecer en la zona
    void OnTriggerStay(Collider other)
    {
        //Animal
        if (NPC_actual.CompareTag("Animal"))
        {
            if (Input.GetKey("l"))
            {
                a.accion_mala();
            }
            if (Input.GetKey("k"))
            {
                a.accion_buena();
            }
        }
        //Comerciante
        if (NPC_actual.CompareTag("Comerciante"))
        {
            if (Input.GetKey("l"))
            {
                c.accion_mala();
            }
            if (Input.GetKey("k"))
            {
                c.accion_buena();
            }
        }
    }
    //Salir de la zona
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
                Debug.Log("Player ha salido de la Zona");
                //OPACIDAD
                centro.opacidad(0f);
        }
    }
    
}
