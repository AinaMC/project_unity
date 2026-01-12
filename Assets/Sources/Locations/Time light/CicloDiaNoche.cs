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
        float angle = Hora * 15f; // 360 / 24
        SolPivot.localRotation = Quaternion.Euler(angle, 0, 0);
        LunaPivot.localRotation = Quaternion.Euler(angle + 180f, 0, 0);
    }

    float CalcularVelocidadMundo()
    {
        float estat = contador.estatus_mundo();

        // velocitat base (24h en X minuts)
        float velocitatBase = 24f / (60f * DuracionDelDiaEnMinutos);

        // MÓN DISTÒPIC (0 a 40)
        if (estat < 40f)
        {
            // 40 = neutral | 0 = màxim distòpic
            float t = Mathf.InverseLerp(40f, 0f, estat);

            // fins a 4x més ràpid
            float factor = Mathf.Lerp(1f, 4f, t);

            return velocitatBase * factor;
        }

        // MÓN NEUTRAL (40 a 60)
        if (estat < 60f)
        {
            // TOTALMENT PLA
            return velocitatBase;
        }

        // MÓN UTÒPIC (60 a 100)
        {
            // 60 = neutral | 100 = màxim utòpic
            float t = Mathf.InverseLerp(60f, 100f, estat);

            // fins a ~3.3x més lent
            float factor = Mathf.Lerp(1f, 0.3f, t);

            return velocitatBase * factor;
        }
    }





}
