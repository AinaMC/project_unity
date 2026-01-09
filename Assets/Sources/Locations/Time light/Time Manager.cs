using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour
{
    [Header("Referències")]
    public CicloDiaNoche ciclo;
    public Light solLight;
    public Light lunaLight;

    [Header("Skybox")]
    [SerializeField] private Texture2D skyboxNight;
    [SerializeField] private Texture2D skyboxDay;

    [Header("Gradients")]
    [SerializeField] private Gradient gradientSol;
    [SerializeField] private Gradient gradientLuna;

    private int lastHour = -1;

    void Update()
    {
        int horaActual = Mathf.FloorToInt(ciclo.Hora);

        if (horaActual != lastHour)
        {
            lastHour = horaActual;
            OnHourChanged(horaActual);
        }

        ActualitzarColorsLlums();
    }

    void ActualitzarColorsLlums()
    {
        float t = ciclo.HoraNormalizada;

        // (6 → 18)
        if (ciclo.Hora >= 6f && ciclo.Hora < 18f)
        {
            solLight.color = gradientSol.Evaluate(t);
        }

        //(18 → 6)
        if (ciclo.Hora >= 18f || ciclo.Hora < 6f)
        {
            lunaLight.color = gradientLuna.Evaluate(t);
        }
    }

    void OnHourChanged(int hour)
    {
        if (hour == 6)
        {
            StartCoroutine(LerpSkybox(skyboxNight, skyboxDay, 1f));
        }
        else if (hour == 18)
        {
            StartCoroutine(LerpSkybox(skyboxDay, skyboxNight, 1f));
        }
    }

    IEnumerator LerpSkybox(Texture2D a, Texture2D b, float time)
    {
        RenderSettings.skybox.SetTexture("_Texture1", a);
        RenderSettings.skybox.SetTexture("_Texture2", b);
        RenderSettings.skybox.SetFloat("_Blend", 0f);

        for (float i = 0; i < time; i += Time.deltaTime)
        {
            RenderSettings.skybox.SetFloat("_Blend", i / time);
            yield return null;
        }

        RenderSettings.skybox.SetTexture("_Texture1", b);
    }
}
