using UnityEngine;

public class npc_identificador : MonoBehaviour
{
    //Centro Interacción
    public centro_interaccion centro;
    public animal a;
    public comerciante c;

    //Entrar en la zona
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player ha entrado en Zona");
            centro.opacidad(1f);
            if (other.CompareTag("Animal"))
            {                
                a.texto();
                Debug.Log("NPC ANIMAL");
            }
            if (other.CompareTag("Comerciante"))
            {
                c.texto();
                Debug.Log("NPC COMERCIANTE");
            }
        }
    }
    //Permanecer en la zona
    void OnTriggerStay(Collider other)
    {

            if (Input.GetKey("l"))
            {
                if (other.CompareTag("Comerciante"))
                {
                    c.accion_mala();
                }
            }
            if (Input.GetKey("k"))
            {
                if (other.CompareTag("Comerciante"))
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
