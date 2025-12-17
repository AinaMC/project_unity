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
       

        //Viento
        //Utopico (favor) --> 1-20
        if (mundo.estatus_mundo() >= 1 && mundo.estatus_mundo() <= 20)
        {
            viento_favor(ex);
            ps.Play();
           

            Debug.Log("Viento a favor activado");
        }
        //Distopico (en contra) --> 80-100
        else if (mundo.estatus_mundo() >= 80 && mundo.estatus_mundo() <= 100)
        {
            viento_contra(ex);
            ps.Play();
            
            Debug.Log("Viento en contra activado");
        }
        else
        {
            ps.Stop();
            mov.cambiar_vel(7f);
            Debug.Log("No hay viento, todo normal");
        }
    }

    //Activar/Desactivar sistema particules
    public void viento_favor(ParticleSystem.ExternalForcesModule ex)
    {            
        ex.multiplier = 0.1f;
        mov.cambiar_vel(100f);
    }
    public void viento_contra(ParticleSystem.ExternalForcesModule ex)
    {
        ex.multiplier = 0.1f;
        mov.cambiar_vel(1f);
    }
}
