using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class Viento : MonoBehaviour
{
    public player_movement mov;
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
        var ex = ps.externalForces;
        ex.enabled = false;

        //Viento
        //Utopico (favor) --> 1-20
        if (mundo.estatus_mundo() >= 1 && mundo.estatus_mundo() <= 20)
        {
            viento_favor(ex);
        }
        //Distopico (en contra) --> 80-100
        else if (mundo.estatus_mundo() >= 80 && mundo.estatus_mundo() <= 100)
        {
            viento_contra(ex);
        }
        else
        {
            ex.enabled = false;
            mov.cambiar_vel(300f);
        }
    }

    //Activar/Desactivar sistema particules
    public void viento_favor(ParticleSystem.ExternalForcesModule ex)
    {            
        ex.enabled = true;
        ex.multiplier = 0.1f;

        mov.cambiar_vel(1000f);
    }
    public void viento_contra(ParticleSystem.ExternalForcesModule ex)
    {
        ex.enabled = true;
        ex.multiplier = 0.1f;
        mov.cambiar_vel(50f);
    }
}
