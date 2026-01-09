using UnityEngine;

public class SkyboxController : MonoBehaviour
{
    [Header("Referències")]
    public CicloDiaNoche ciclo;
    public WorldManagement worldManager;

    [Header("Material Skybox")]
    public Material skyboxMaterial;

    [Header("Textures Dia / Nit")]
    public Texture2D diaDistopic;
    public Texture2D nitDistopic;

    public Texture2D diaNeutre;
    public Texture2D nitNeutre;

    public Texture2D diaUtopic;
    public Texture2D nitUtopic;

    void Update()
    {
        ActualitzarTextures();
        ActualitzarBlend();
    }

    void ActualitzarBlend()
    {
        float hora = ciclo.Hora;
        float blend;

        // Nit estable
        if (hora < 5f || hora >= 18f)
        {
            blend = 1f;
        }
        // Alba (nit a dia)
        else if (hora < 7f)
        {
            blend = Mathf.InverseLerp(7f, 5f, hora); // 1 a 0
        }
        // Dia estable
        else if (hora < 17f)
        {
            blend = 0f;
        }
        // Posta (dia a nit)
        else
        {
            blend = Mathf.InverseLerp(17f, 18f, hora); // 0 a 1
        }

        skyboxMaterial.SetFloat("_Blend", blend);
    }




    void ActualitzarTextures()
    {
        float estat = worldManager.estatus_mundo(); // 0–100

        Texture2D dia = diaNeutre;
        Texture2D nit = nitNeutre;

        if (estat < 30f)
        {
            dia = diaDistopic;
            nit = nitDistopic;
        }
        else if (estat < 70f)
        {
            dia = diaNeutre;
            nit = nitNeutre;
        }
        else
        {
            dia = diaUtopic;
            nit = nitUtopic;
        }

        skyboxMaterial.SetTexture("_Texture1", dia);
        skyboxMaterial.SetTexture("_Texture2", nit);
    }
}
