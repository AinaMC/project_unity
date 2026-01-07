using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CicloDiaNoche : MonoBehaviour
{
    [Range(0.0f,24f)] public float Hora = 12;
    
    public Transform Sol;

    public float DuracionDelDiaEnMinutos = 1; //aqui vemos cuanto dura el dia en minutos, Los juegos usan 24 min normalmente

    private float SolX;
 
    // Update is called once per frame
    void Update()
    {
        Hora += Time.deltaTime * (24 / (60 * DuracionDelDiaEnMinutos));

        if (Hora >= 24)
        {
            Hora = 0;
        }

        RotacionSol();
    }
    
    void RotacionSol()
    {
        SolX = 15 * Hora; //15 x 24 son 360 grados que ha de dar la vuelta el sol

        Sol.localEulerAngles = new Vector3 (SolX, 0, 0);

        if (Hora < 6 || Hora > 18)
        {
            Sol.GetComponent<Light>().intensity = 0;
        }
        else
        {
            Sol.GetComponent<Light>().intensity = 1; //Actualizar con la intensidad real
        }
    }
}
