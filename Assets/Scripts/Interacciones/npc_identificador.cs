using UnityEngine;
//Este script hace:
//IDENTIFICAR NPC y redirigirlo a su script
//Asi solo hay 1 solo script para todas las interacciones
public class npc_identificador : MonoBehaviour
{
    public GameObject NPC_actual;
    //Centro Interacción
    public centro_interaccion centro;
    
    public animals a;
    public comerciante c;

    //Entrar en la zona
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Player ha entrado en Zona");
            centro.opacidad(1f);
            if (NPC_actual.gameObject.CompareTag("Animal"))
            {
                a.texto();
                Debug.Log("NPC ANIMAL");
            }
            if (NPC_actual.gameObject.CompareTag("Comerciante"))
            {
                c.texto();
                Debug.Log("NPC COMERCIANTE");
            }
  
        }
    }
    //Permanecer en la zona
    void OnCollisionStay(Collision other)
    {

            //Accion Mala
            if (Input.GetKey(KeyCode.L))
            {
                //Animal
                if (NPC_actual.gameObject.CompareTag("Animal"))
                {
                    a.accion_mala();
                }
                //Comerciante
                if (NPC_actual.gameObject.CompareTag("Comerciante"))
                {
                    c.accion_mala();
                }
                Debug.Log("Opcion Mala");
            }


            //Accion Buena
            if (Input.GetKey(KeyCode.K))
            {
                //Animal
                if (NPC_actual.gameObject.CompareTag("Animal"))
                {
                    a.accion_buena();
                }
                //Comerciante
                if (NPC_actual.gameObject.CompareTag("Comerciante"))
                {
                    c.accion_buena();
                }
                Debug.Log("Opcion Buena");
            }

       
    }
    //Salir de la zona
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
                Debug.Log("Player ha salido de la Zona");
                //OPACIDAD
                centro.opacidad(0f);
        }
    }
 }