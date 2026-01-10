using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Este script hace:
//IDENTIFICAR NPC y redirigirlo a su script
//Asi solo hay 1 solo script para todas las interacciones
public class npc_identificador : MonoBehaviour
{
    public GameObject NPC_actual;
    //Centro Interacción
    public centro_interaccion centro;
    public string nombre= "";

    [Header("NPC-Scripts")]//dividir en el editor visualmente
    public animals a;
    public comerciante c;
    public arma arma;
    public soldado_quieto soldado;

    void Start()
    {
        nombre = "";
    }
    //Entrar en la zona
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Player ha entrado en Zona");
            centro.opacidad(1f);
            if (NPC_actual.gameObject.CompareTag("Animal"))
            {
                nombre = "Animal";
                a.texto();
                Debug.Log("NPC ANIMAL");
            }
            if (NPC_actual.gameObject.CompareTag("Comerciante"))
            {
                nombre = "Comerciante";
                c.texto();
                Debug.Log("NPC COMERCIANTE");
            }
            if (NPC_actual.gameObject.CompareTag("Arma"))
            {
                nombre = "Arma";
                arma.texto();
                Debug.Log("NPC ARMA");
            }
            if (NPC_actual.gameObject.CompareTag("Soldado"))
            {
                nombre = "Soldado";
                soldado.texto();
                Debug.Log("NPC SOLDADO");
            }
            //desbloquear cursor

            //Cursor.lockState = CursorLockMode.Confined;

            nombre = NPC_actual.gameObject.tag;
            FixedUpdate();
        }          

    }

    private void FixedUpdate()
    {
        if (nombre != "")
        {
            //Accion Mala
            if (Input.GetMouseButtonDown(0))
            {
                //Animal
                if (nombre == "Animal")
                {
                    a.accion_mala();
                }
                //Comerciante
                if (nombre == "Comerciante")
                {
                    c.accion_mala();
                }
                //Arma
                if (nombre == "Arma")
                {
                    arma.accion_mala();
                }
                //Soldado
                if (nombre == "Soldado")
                {
                    soldado.accion_mala();
                }
                Debug.Log("Opcion Mala");
                centro.opacidad(0f);

                //Cursor.lockState = CursorLockMode.Locked;

                nombre = "";
            }


            //Accion Buena
            if (Input.GetMouseButtonDown(1))
            {
                //Animal
                if (nombre == "Animal")
                {
                    a.accion_buena();
                }
                //Comerciante
                if (nombre == "Comerciante")
                {
                    c.accion_buena();
                }
                //Arma
                if (nombre == "Arma")
                {
                    arma.accion_buena();
                    Destroy(NPC_actual);
                }
                //Soldado
                if (nombre == "Soldado")
                {
                    soldado.accion_buena();
                }
                Debug.Log("Opcion Buena");
                centro.opacidad(0f);

                //Cursor.lockState = CursorLockMode.Locked;

                nombre = "";
            }
        }
    }

    //public void DestinationButton(Button destinationButton)
    //{
    //    destinationButton.Select();
    //    Debug.Log(destinationButton.name);
    //}
    
    //Salir de la zona
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player ha salido de la Zona");
            //OPACIDAD
            centro.opacidad(0f);
            nombre = "";
        }
        //Escondemos el cursor

        //Cursor.lockState = CursorLockMode.Locked;

    }
 }