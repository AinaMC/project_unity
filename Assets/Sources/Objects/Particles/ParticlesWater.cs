using UnityEngine;

public class ParticlesWater : MonoBehaviour
{
    public WorldManagement contador; //llamando al script WorldManagement
    private float comprobador;

    ParticleSystem agua;
    private ParticleSystem.MainModule mainAgua;
    private ParticleSystem.EmissionModule emissionAgua;
    private ParticleSystem.ColorOverLifetimeModule colorAgua;
    private ParticleSystem.TextureSheetAnimationModule animationAgua;

    public Material ColorAguaFuente;
    

    void Awake()
    {
        agua = GameObject.Find("Water").GetComponent<ParticleSystem>();

        mainAgua = agua.main;
        emissionAgua = agua.emission;
        colorAgua = agua.colorOverLifetime;
        animationAgua = agua.textureSheetAnimation;

        comprobador = contador.estatus_mundo();
    }
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        comprobador = contador.estatus_mundo();
        //AudioManagment.PlaySound(SoundType.SFX);
    }

    // Update is called once per frame
    void Update()
    {
        if (comprobador != contador.estatus_mundo())
        {
            comprobador = contador.estatus_mundo();
            waterChange(comprobador);
        }

        
    }
    public enum EstadoAgua
    {
        Distopia,
        Neutro,
        Utopia
    }
    private EstadoAgua estadoActual;

    private void waterChange(float numComprobador)
    {
        
        EstadoAgua nuevoEstado;

        if (numComprobador < 15)
            nuevoEstado = EstadoAgua.Distopia;
        else if (numComprobador > 85)
            nuevoEstado = EstadoAgua.Utopia;
        else
            nuevoEstado = EstadoAgua.Neutro;

        if (nuevoEstado == estadoActual)
            return;

        estadoActual = nuevoEstado;

        switch (estadoActual)
        {
            case EstadoAgua.Distopia:
                mainAgua.startColor = new Color(0f, 0f, 0f, 1f);
                emissionAgua.rateOverTime = 100;

                colorAgua.enabled = true;
                Gradient gradDistopia = new Gradient();
                gradDistopia.SetKeys(
                    new GradientColorKey[]
                {
                new GradientColorKey(Color.black, 0f), //negro
                new GradientColorKey(Color.green, 0.11f), //verde
                },
                    new GradientAlphaKey[]
                    {
                    new GradientAlphaKey(1f, 0.38f), // opaco
                    new GradientAlphaKey(0f, 1f) //al final transparente
                    }
                );
                colorAgua.color = gradDistopia;

                ColorAguaFuente.color = new Color(0f, 0f, 0f);
                Debug.Log("Agua Distopia");
                break;

            case EstadoAgua.Utopia:
                mainAgua.startColor = new Color(0.85f, 0.95f, 1f, 0.08f); //azul muy clarito y transparente
                emissionAgua.rateOverTime = 300;

                colorAgua.enabled = true;
                Gradient gradUtopia = new Gradient();
                gradUtopia.SetKeys(
                    new GradientColorKey[]
                {
                new GradientColorKey(Color.white, 0),
                new GradientColorKey(Color.white, 1),
                },
                    new GradientAlphaKey[]
                    {
                    new GradientAlphaKey(1f, 0.5f), // opaco
                    new GradientAlphaKey(0f, 1f) //al final transparente
                    }
                );
                colorAgua.color = gradUtopia;

                ColorAguaFuente.color = new Color(1f, 1f, 1f);
                Debug.Log("Agua Utopia");
                break;

            case EstadoAgua.Neutro:
                mainAgua.startColor = new Color(0.85f, 0.95f, 1f, 0.03f); //azul muy clarito y transparente
                emissionAgua.rateOverTime = 150;

                colorAgua.enabled = true;
                Gradient gradNeutro = new Gradient();
                gradNeutro.SetKeys(
                    new GradientColorKey[]
                {
                new GradientColorKey(Color.white, 0),
                new GradientColorKey(Color.white, 1),
                },
                    new GradientAlphaKey[]  
                    {
                    new GradientAlphaKey(1f, 0.38f),
                    new GradientAlphaKey(0f, 1f)
                    }
                );
                colorAgua.color = gradNeutro;

                ColorAguaFuente.color = new Color(0.68f, 0.9f, 0.7f);
                Debug.Log("El agua es normal");
                break;
        }

        agua.Clear();
        agua.Play();
    }
}
