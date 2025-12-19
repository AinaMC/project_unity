using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class Viento : MonoBehaviour
{
    public player_movement mov;
    public WorldManagement estado;
    public Texto_Contador mundo;

    //Viento a Favor o en Contra
    //Neutral --> 21-79
    //Utopico (favor) --> 1-20
    //Distopico (en contra) --> 80-100

    void Start()
    {
        
    }

    void FixedUpdate()
    {        
        ParticleSystem ps = GetComponent<ParticleSystem>();  
        //var ex = ps.externalForces;
        var main = ps.main;
        var transf = ps.transform;
   
        //Viento
        //Utopico (favor) --> 1-20
        if (mundo.estatus_mundo() >= 1 && mundo.estatus_mundo() <= 20)
        {
            viento_favor(main);
            transf.rotation = Quaternion.Euler(0, 180, 0);
            Debug.Log("Viento a favor activado");
        }
        //Distopico (en contra) --> 80-100
        else if (mundo.estatus_mundo() >= 80 && mundo.estatus_mundo() <= 100)
        {
            viento_contra(main);
            transf.rotation = Quaternion.Euler(0, 0, 0);
            Debug.Log("Viento en contra activado");
        }
        else
        {
            mov.cambiar_vel(300f);
            transf.rotation = Quaternion.Euler(0, 180, 0);
            main.startLifetime = 0.0001f;
            Debug.Log("No hay viento, todo normal");
        }
    }

    //Activar/Desactivar sistema particules
    public void viento_favor(ParticleSystem.MainModule main)
    {            
        main.startLifetime = 5f;
        main.startSpeed = 10f;
        mov.cambiar_vel(600f);
    }
    public void viento_contra(ParticleSystem.MainModule main)
    {
        main.startLifetime = 5f;
        main.startSpeed = 30f;
        mov.cambiar_vel(100f);
    }
}
