using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class Viento : MonoBehaviour
{
    CharacterController a;
    public Vector3 FuerzaViento;

    //Viento a Favor o en Contra
    //Neutral --> 21-79
    //Utopico (favor) --> 1-20
    //Distopico (en contra) --> 80-100
    void Start()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var ex = ps.externalForces;
        ex.enabled = true;
        ex.multiplier = 0.1f;
    }


    void Update()
    {
    }

    public void viento_favor()
    {
        
    }
    public void viento_contra()
    {

    }
}
