using UnityEngine;

public class CicloDiaNoche : MonoBehaviour
{
    [Range(0f, 24f)]
    public float Hora = 12f;

    public Transform Sol;
    public Transform Luna;

    public float DuracionDelDiaEnMinutos = 1f;


    public float HoraNormalizada => Hora / 24f; // 0–1

    void Update()
    {
        Hora += Time.deltaTime * (24f / (60f * DuracionDelDiaEnMinutos));
        if (Hora >= 24f)
            Hora = 0f;

        RotacionSolYLuna();
        ActualitzarLlums();
    }

    void RotacionSolYLuna()
    {
        float angle = Hora * 15f;
        Sol.localEulerAngles = new Vector3(angle, 0, 0);
        Luna.localEulerAngles = new Vector3(angle + 180f, 0, 0); // oposada
    }

    void ActualitzarLlums()
    {
        Light solLight = Sol.GetComponent<Light>();
        Light lunaLight = Luna.GetComponent<Light>();

        // SOL: actiu de 6 a 18
        solLight.intensity = (Hora >= 6f && Hora < 18f) ? 2f : 0f;

        // LLUNA: actiu de 18 a 6
        lunaLight.intensity = (Hora >= 18f || Hora < 6f) ? 0.5f : 0f;
    }
}
