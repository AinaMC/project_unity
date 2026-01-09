using UnityEngine;

public class CicloDiaNoche : MonoBehaviour
{
    [Range(0f, 24f)]
    public float Hora = 12f;

    public Transform SolPivot;
    public Transform LunaPivot;

    public float DuracionDelDiaEnMinutos = 1f;

    public float HoraNormalizada => Hora / 24f;

    void Update()
    {
        Hora += Time.deltaTime * (24f / (60f * DuracionDelDiaEnMinutos));
        if (Hora >= 24f) Hora = 0f;

        RotarAstros();
    }

    void RotarAstros()
    {
        float angle = Hora * 15f; // 360 / 24
        SolPivot.localRotation = Quaternion.Euler(angle, 0, 0);
        LunaPivot.localRotation = Quaternion.Euler(angle + 180f, 0, 0);
    }
}
