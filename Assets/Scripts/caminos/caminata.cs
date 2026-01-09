using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//ok
public class caminata : MonoBehaviour
{
    public NavMeshAgent AI;
    public float velocidad;
    public Transform[] Objetivos; //Pts a los que se puede dirigir el NPC
    Transform Objetivo; //Punto especifico al que ira
    float Distancia; //saber disstancia NPC y obj

    //[Header("Animaciones")]//dividir en el editor visualmente
    //public Animation anim;
    //public string caminandoAnim;

    void Start()
    {
        //Elegir de manera aleatoria el obj
        Objetivo = Objetivos[Random.Range(0, Objetivos.Length)];
        //anim.Play(caminandoAnim);
    }

    void Update()
    {
        //NPC detecte la distancia entre el mismo, y el objetivo
        Distancia = Vector3.Distance(transform.position, Objetivo.position);

        if (Distancia < 2)
        {
            //cuando llegue a su obj elegir otro
            Objetivo = Objetivos[Random.Range(0, Objetivos.Length)];
        }
        //Enviamos el NPC al obj
        AI.destination = Objetivo.position;
        //Velocidad a la que ira
        AI.speed = velocidad;
    }
}
