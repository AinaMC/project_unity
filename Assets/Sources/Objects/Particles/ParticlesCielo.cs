using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class ParticlesCielo : MonoBehaviour
{
    public WorldManagement contador; //llamando al script WorldManagement
    private float comprobador;


    ParticleSystem trueno;
    ParticleSystem stars;
    ParticleSystem sakura;

    private ParticleSystem.EmissionModule emissionTrueno;
    private ParticleSystem.EmissionModule emissionStars;
    private ParticleSystem.EmissionModule emissionSakura;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trueno = GameObject.Find("Trueno").GetComponent<ParticleSystem>();
        stars = GameObject.Find("Stars").GetComponent<ParticleSystem>();
        sakura = GameObject.Find("sakura").GetComponent<ParticleSystem>();

        emissionTrueno = trueno.emission;
        emissionStars = stars.emission;
        emissionSakura = sakura.emission;

        // Inicialmente todos están apagados
        emissionTrueno.enabled = false;
        emissionStars.enabled = false;
        emissionSakura.enabled = false;

        comprobador = contador.estatus_mundo();
    }

    // Update is called once per frame
    void Update()
    {
        if (comprobador != contador.estatus_mundo())
        {
            comprobador = contador.estatus_mundo();
            cieloChange(comprobador);
        }
    }

    private void cieloChange(float numComprobador)
    {
        var mainTrueno = trueno.main;
        var emissionTrueno = trueno.emission;

        var mainStars = stars.main;
        var emissionStars = stars.emission;

        var mainSakura = sakura.main;
        var emissionSakura = sakura.emission;

        if (numComprobador >= 70) // Utopía
        {
            emissionStars.enabled = true;
            emissionSakura.enabled = true;
            Debug.Log("Cielo Utopico");
            emissionTrueno.enabled = false;

            if (numComprobador > 80)
            {
                emissionStars.rateOverTime = +5;
                Debug.Log("Se han añadido más estrellas");
            }

        }
        else if (numComprobador <= 30) // Distopía
        {
            emissionTrueno.enabled = true;
            AudioManagment.PlaySound(SoundType.SFX, 1);

            emissionStars.enabled = false;
            emissionSakura.enabled = false;

            Debug.Log("Cielo Distopico");
            if (numComprobador < 20)
            {
                emissionTrueno.rateOverTime = +5;
                Debug.Log("Se han añadido más truenos");
            }

        }
        else // Neutro
        {
            emissionTrueno.enabled = false;
            emissionStars.enabled = false;
            emissionSakura.enabled = false;

            Debug.Log("Cielo Neutro");
        }
    }
}
