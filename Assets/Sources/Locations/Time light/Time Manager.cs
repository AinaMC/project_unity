using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Header("Referències")]
    public CicloDiaNoche ciclo;
    public Light sol;
    public Light lluna;


    [Header("Fanals")]
    public Light[] fanals;

    [Header("Intensitats")]
    public float intensitatSol = 1.2f;
    public float intensitatLluna = 0.3f;
    public float intensitatFanals = 1f;

    [Header("Velocitat de fade")]
    public float velocitatFade = 2f;

    [Header("Gradients de color")]
    public Gradient gradientSol;
    public Gradient gradientLluna;
    public Gradient gradientAmbient;

    [Header("Fanals emissió (shader)")]
    public Renderer[] vidresFanals;
    public Color colorEmissiu = Color.white;
    public float intensitatEmissiva = 2f;

    private bool eraDeDia = true;

    void Update()
    {
        ActualitzarLlums();
        ActualitzarGradient();
        ActualitzarFanals();
    }

    void ActualitzarFanals()
    {
        float hora = ciclo.Hora;

        // Dia: 6–18
        bool esDeDia = hora >= 6f && hora < 18f;

        // Només actuem quan canvia dia/nit
        if (esDeDia == eraDeDia)
            return;

        foreach (Renderer r in vidresFanals)
        {
            Material[] mats = r.materials;

            // Material 0 = vidre
            Material vidre = mats[2];

            if (esDeDia)
            {
                // APAGAR emissió
                vidre.DisableKeyword("_EMISSION");
                vidre.SetColor("_EmissionColor", Color.black);
            }
            else
            {
                // ENCENDRE emissió
                vidre.EnableKeyword("_EMISSION");
                vidre.SetColor("_EmissionColor", colorEmissiu * intensitatEmissiva);
            }

            mats[2] = vidre;
            r.materials = mats;
        }

        eraDeDia = esDeDia;
    }







    void ActualitzarGradient()
    {
        float hora = ciclo.Hora;
        float blend;

        // EXACTAMENT el mateix càlcul que el skybox
        if (hora < 5f || hora >= 19f)
            blend = 1f;
        else if (hora < 7f)
            blend = Mathf.InverseLerp(5f, 7f, hora);
        else if (hora < 17f)
            blend = 0f;
        else
            blend = Mathf.InverseLerp(19f, 17f, hora);

        // COLORS
        sol.color = gradientSol.Evaluate(1f - blend);
        lluna.color = gradientLluna.Evaluate(blend);
        RenderSettings.ambientLight = gradientAmbient.Evaluate(blend);
        RenderSettings.fogColor = RenderSettings.ambientLight;
    }

    void ActualitzarLlums()
    {
        float hora = ciclo.Hora;
        bool esDeDia = hora >= 6f && hora < 18f;

        float solTarget = esDeDia ? intensitatSol : 0f;
        float llunaTarget = esDeDia ? 0f : intensitatLluna;
        float fanalsTarget = esDeDia ? 0f : intensitatFanals;

        sol.intensity = Mathf.Lerp(sol.intensity, solTarget, velocitatFade * Time.deltaTime);
        lluna.intensity = Mathf.Lerp(lluna.intensity, llunaTarget, velocitatFade * Time.deltaTime);

        foreach (Light f in fanals)
        {
            f.intensity = Mathf.Lerp(f.intensity, fanalsTarget, velocitatFade * Time.deltaTime);
        }
    }
}
