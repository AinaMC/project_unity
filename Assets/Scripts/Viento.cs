using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class Viento : MonoBehaviour
{
    public player_movement mov;
    public WorldManagement estado;
    //public Transform wind;
    
    //Viento a Favor o en Contra
    //Neutral --> 21-79
    //Utopico (favor) --> 1-20
    //Distopico (en contra) --> 80-100


    void FixedUpdate()
    {        
        ParticleSystem ps = GetComponent<ParticleSystem>();  
        //var ex = ps.externalForces;
        var main = ps.main;
        var transf = ps.transform;

        //Viento
        //Utopico (favor) --> 1-20
        if (estado.estatus_mundo() >= 80 && estado.estatus_mundo() <= 100)
        {
            viento_favor(main);
            //transf.rotation = Quaternion.Euler(0, 180, 0);

        }
        //Distopico (en contra) --> 80-100
        else if (estado.estatus_mundo() >= 1 && estado.estatus_mundo() <= 20)
        {
            viento_contra(main);
        }
        else
        {
            mov.cambiar_vel(7f);
            main.startLifetime = 0.0001f;
            //wind.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    //Activar/Desactivar sistema particules
    public void viento_favor(ParticleSystem.MainModule main)
    {            
        main.startLifetime = 5f;
        main.startSpeed = 55f;
        mov.cambiar_vel(6f);
    }
    public void viento_contra(ParticleSystem.MainModule main)
    {
        main.startLifetime = 5f;
        main.startSpeed = 5f;
        mov.cambiar_vel(1f);
    }
}
