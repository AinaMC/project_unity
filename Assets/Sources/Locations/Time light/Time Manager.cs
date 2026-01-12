using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Header("World Management")]
    public WorldManagement contador;

    [Header("Referències")]
    public CicloDiaNoche ciclo;
    public Light sol;
    public Light lluna;

    [Header("Fanals")]
    public Light[] fanals;
    public Renderer[] vidresFanals; // Renderer del mesh que conté el material emissiu

    [Header("Intensitats")]
    public float intensitatSol = 1.2f;
    public float intensitatLluna = 0.3f;
    public float intensitatFanals = 1f;

    [Header("Velocitat de fade")]
    public float velocitatFade = 2f;

    [Header("Gradients Neutrals")]
    public Gradient gradientSol;
    public Gradient gradientLluna;
    public Gradient gradientAmbient;
    public Gradient gradientFanals;  

    [Header("Gradients Utòpic")]
    public Gradient gradientSolUtopic;
    public Gradient gradientLlunaUtopic;
    public Gradient gradientFanalsUtopic;
    public Gradient gradientAmbientUtopic;

    [Header("Gradients Distòpic")]
    public Gradient gradientSolDistopic;
    public Gradient gradientLlunaDistopic;
    public Gradient gradientFanalsDistopic; 
    public Gradient gradientAmbientDistopic;

    [Header("Emissió fanals")]
    public Color colorEmissiu = Color.white;
    public float intensitatEmissiva = 2f;
       
    void Update()
    {
        ActualitzarLlums();
        ActualitzarColors();
        ActualitzarEmissioFanals();
    }

    // ───────────────────────── LLUMS ─────────────────────────

    void ActualitzarLlums()
    {
        float hora = ciclo.Hora;
        bool esDeDia = hora >= 6f && hora < 18f;

        sol.intensity = Mathf.Lerp(
            sol.intensity,
            esDeDia ? intensitatSol : 0f,
            velocitatFade * Time.deltaTime
        );

        lluna.intensity = Mathf.Lerp(
            lluna.intensity,
            esDeDia ? 0f : intensitatLluna,
            velocitatFade * Time.deltaTime
        );

        foreach (Light f in fanals)
        {
            f.intensity = Mathf.Lerp(
                f.intensity,
                esDeDia ? 0f : intensitatFanals,
                velocitatFade * Time.deltaTime
            );
        }
    }

    // ───────────────────────── COLORS ─────────────────────────

    void ActualitzarColors()
    {
        float hora = ciclo.Hora;
        float blend;

        // Dia a Nit (coherent amb el skybox)
        if (hora < 5f || hora >= 19f)
            blend = 1f;
        else if (hora < 7f)
            blend = Mathf.InverseLerp(5f, 7f, hora);
        else if (hora < 17f)
            blend = 0f;
        else
            blend = Mathf.InverseLerp(19f, 17f, hora);

        Gradient solG = SeleccionarGradient(
            gradientSol,
            gradientSolUtopic,
            gradientSolDistopic
        );

        Gradient llunaG = SeleccionarGradient(
            gradientLluna,
            gradientLlunaUtopic,
            gradientLlunaDistopic
        );

        Gradient ambientG = SeleccionarGradient(
            gradientAmbient,
            gradientAmbientUtopic,
            gradientAmbientDistopic
        );

        Color ambientColor = ambientG.Evaluate(blend);
        RenderSettings.ambientLight = ambientColor;
        RenderSettings.fogColor = ambientColor;

        sol.color = solG.Evaluate(1f - blend);
        lluna.color = llunaG.Evaluate(blend);

    }

    Gradient SeleccionarGradient(Gradient neutral, Gradient utopic, Gradient distopic)
    {
        float estat = contador.estatus_mundo();

        if (estat < 30f) return distopic;
        if (estat < 70f) return neutral;
        return utopic;
    }

    // ───────────────────────── FANALS (EMISSIÓ) ─────────────────────────

    

    void ActualitzarEmissioFanals()
    {
        float hora = ciclo.Hora;
        bool esDeNit = hora < 6f || hora >= 18f;

        // Gradient segons l'estat del món (utòpic / neutral / distòpic)
        Gradient fanalsG = SeleccionarGradient(
            gradientFanals,
            gradientFanalsUtopic,
            gradientFanalsDistopic
        );

        // Color segons hora normalitzada
        Color colorFanals = fanalsG.Evaluate(ciclo.HoraNormalizada);

        // Aplicar color a les llums només de nit
        foreach (Light f in fanals)
        {
            f.color = esDeNit ? colorFanals : Color.black;
            f.intensity = esDeNit ? intensitatFanals : 0f; // fade si vols més tard
        }

        // Aplicar el mateix color a l'emissió del vidre dels fanals
        foreach (Renderer r in vidresFanals)
        {
            Material vidre = r.materials[2]; // material emissiu

            if (esDeNit)
            {
                vidre.EnableKeyword("_EMISSION");
                vidre.SetColor("_EmissionColor", colorFanals * intensitatEmissiva);
            }
            else
            {
                vidre.DisableKeyword("_EMISSION");
                vidre.SetColor("_EmissionColor", Color.black);
            }

            // Reassignem el material per Unity
            Material[] mats = r.materials;
            mats[2] = vidre;
            r.materials = mats;
        }
    }



}
