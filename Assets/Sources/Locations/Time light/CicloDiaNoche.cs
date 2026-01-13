using UnityEngine;

public class CicloDiaNoche : MonoBehaviour
{
    [Header("Hora del dia")]
    [Range(0f, 24f)]
    public float Hora = 12f;

    [Header("Astros")]
    public Transform SolPivot;
    public Transform LunaPivot;

    [Header("Equivalente a tiempo real")]
    public float DuracionDelDiaEnMinutos = 24f;

    public float HoraNormalizada => Hora / 24f;

    [Header("Morld Manager")]
    public WorldManagement contador;


    void Update()
    {
        float velocidadMundo = CalcularVelocidadMundo();

        Hora += Time.deltaTime * velocidadMundo;
        if (Hora >= 24f) Hora = 0f;

        RotarAstros();
    }


    void RotarAstros()
    {
        float angle = Hora * 15f;
        SolPivot.localRotation = Quaternion.Euler(angle, 0, 0);
        LunaPivot.localRotation = Quaternion.Euler(angle + 180f, 0, 0);
    }

    float CalcularVelocidadMundo()
    {
        float estat = contador.estatus_mundo();


        float velocitatBase = 24f / (60f * DuracionDelDiaEnMinutos);

        // MÓN DISTÒPIC 
        if (estat < 40f)
        {

            float t = Mathf.InverseLerp(40f, 0f, estat);

            // fins a 4x més ràpid
            float factor = Mathf.Lerp(1f, 4f, t);

            return velocitatBase * factor;
        }

        // MÓN NEUTRAL 
        if (estat < 60f)
        {

            return velocitatBase;
        }

        // MÓN UTÒPIC 
        {

            float t = Mathf.InverseLerp(60f, 100f, estat);


            float factor = Mathf.Lerp(1f, 0.3f, t);

            return velocitatBase * factor;
        }
    }





}
