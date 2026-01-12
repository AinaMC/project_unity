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


    void /*Fixed*/Update() //canvi a void cambiarViento (int estado), arriba void update con estado
    {        
        ParticleSystem ps = GetComponent<ParticleSystem>();  
        //var ex = ps.externalForces;
        var main = ps.main;
        var transf = ps.transform;

        var colorViento = ps.colorOverLifetime;
        var animationViento = ps.textureSheetAnimation;   

        //Viento
        //Utopico (favor) --> 1-20
        if (estado.estatus_mundo() >= 80 && estado.estatus_mundo() <= 100)
        {
            viento_favor(main, colorViento, animationViento);
            //transf.rotation = Quaternion.Euler(0, 180, 0);

        }
        //Distopico (en contra) --> 80-100
        else if (estado.estatus_mundo() >= 1 && estado.estatus_mundo() <= 20)
        {
            viento_contra(main, colorViento, animationViento);
        }
        else
        {
            mov.cambiar_vel(7f);
            main.startLifetime = 0.0001f;
            //wind.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    //Activar/Desactivar sistema particules
    public void viento_favor(ParticleSystem.MainModule main, ParticleSystem.ColorOverLifetimeModule colorViento, ParticleSystem.TextureSheetAnimationModule animationViento)
    {            
        main.startLifetime = 5f;
        main.startSpeed = 55f;
        mov.cambiar_vel(6f);

        main.startColor = new Color(1f, 0.8f, 0.4f);
        //Gradient grad = new Gradient();
        //grad.SetKeys(
        //    new GradientColorKey[]
        //{
        //        new GradientColorKey(new Color(1f, 0.7f, 0.5f), 0),
        //        new GradientColorKey(new Color(1f, 0.8f, 0.4f), 1),
        //},
        //new GradientAlphaKey[]
        //{
        //        new GradientAlphaKey(1f, 1f), //opaco, principio
        //        new GradientAlphaKey(0.5f, 1f) //transparente, final
        //}
        //);
        //colorViento.color = grad;
        //animationViento.enabled = true;
        //animationViento.startFrame = new ParticleSystem.MinMaxCurve(10f, 11f);


    }
    public void viento_contra(ParticleSystem.MainModule main, ParticleSystem.ColorOverLifetimeModule colorViento, ParticleSystem.TextureSheetAnimationModule animationViento)
    {
        main.startLifetime = 5f;
        main.startSpeed = 5f;
        mov.cambiar_vel(1f);

        main.startColor = new Color(0f, 0f, 0f); //(0.63f, 0.47f, 0.34f)
        //Gradient grad = new Gradient();
        //grad.SetKeys(
        //    new GradientColorKey[]
        //{
        //        new GradientColorKey(new Color(0.63f, 0.47f, 0.34f), 0),
        //        new GradientColorKey(new Color(0.55f, 0.5f, 0.47f), 1),
        //},
        //new GradientAlphaKey[]
        //{
        //        new GradientAlphaKey(1f, 1f), //opaco, principio
        //        new GradientAlphaKey(0.5f, 1f) //transparente, final
        //}
        //);
        //colorViento.color = grad;
        //animationViento.enabled = true;
        //animationViento.startFrame = new ParticleSystem.MinMaxCurve(13f);
    }
}
