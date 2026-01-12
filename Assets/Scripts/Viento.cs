using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class Viento : MonoBehaviour
{
    public player_movement mov;
    public WorldManagement estado;
    
    //Viento a Favor o en Contra
    //Neutral --> 21-79
    //Utopico (favor) --> 1-20
    //Distopico (en contra) --> 80-100


    void Update()
    {
        //Particles
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var colorViento = ps.colorOverLifetime;
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
        mov.cambiar_vel(15f);
        //Viento
        main.startLifetime = 5f;
        main.startSpeed = 55f;
        main.startColor = new Color(1f, 0.8f, 0.4f);
    }
    public void viento_contra(ParticleSystem.MainModule main)
    {
        mov.cambiar_vel(4f);
        //Viento
        main.startLifetime = 5f;
        main.startSpeed = 5f;
        main.startColor = new Color(0f, 0f, 0f);
    }
}
