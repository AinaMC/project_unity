using System.Diagnostics.CodeAnalysis;
//using System.Drawing;
using UnityEngine;

public class ParticlesCasas : MonoBehaviour
{
    public WorldManagement contador; //llamando al script WorldManagement
    private float comprobador;

    ParticleSystem fuego;
    ParticleSystem.MainModule mainFuego;
    ParticleSystem.EmissionModule emissionFuego;
    ParticleSystem.ShapeModule shapeFuego;
    ParticleSystem.ColorOverLifetimeModule colorFuego;
    ParticleSystem.SizeOverLifetimeModule sizeFuego;

    public Transform parentCasas;
    private MeshRenderer[] meshesCasas;
    public GameObject nomParentCasa;
    public MeshRenderer meshCasa;

    ParticleSystem clean;
    ParticleSystem.MainModule mainLimpio;
    ParticleSystem.ShapeModule shapeLimpio;

    void Awake()
    {
        //fuego = GameObject.Find("Fuego").GetComponent<ParticleSystem>();
        fuego = GameObject.Find("FuegoCasa").GetComponent<ParticleSystem>();
        clean = GameObject.Find("Clean").GetComponent<ParticleSystem>();
        
        mainFuego = fuego.main;
        emissionFuego = fuego.emission;
        shapeFuego = fuego.shape;
        colorFuego = fuego.colorOverLifetime;
        sizeFuego = fuego.sizeOverLifetime;

        meshesCasas = parentCasas.GetComponentsInChildren<MeshRenderer>();
        Debug.Log("Se han encontrado " + meshesCasas.Length + " casas.");

        mainLimpio = clean.main;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        comprobador = contador.estatus_mundo();
    }

    // Update is called once per frame
    void Update()
    {
        if (comprobador != contador.estatus_mundo())
        {
            comprobador = contador.estatus_mundo();
            fireChange(comprobador); //fuego
            cleanChange(comprobador); //limpio
        }
    }

    private void fireChange(float numComprobador)
    {
        if (numComprobador < 30) //random por distopia
        {
            if (meshesCasas.Length > 0)
            {
                int index = Random.Range(0, meshesCasas.Length);
                shapeFuego.shapeType = ParticleSystemShapeType.Mesh;
                shapeFuego.mesh = meshesCasas[index].GetComponent<MeshFilter>().sharedMesh;
                Debug.Log("Se quema una casa");
            }
        }

        if (numComprobador <= 40) //IMPORTANTE este deberia ser al pasar un rato con el pequeño
        {
            mainFuego.startLifetime = 10f;
            mainFuego.startSize = new ParticleSystem.MinMaxCurve(0.5f, 3.5f);
            emissionFuego.rateOverTime = 50;

            shapeFuego.shapeType = ParticleSystemShapeType.Mesh;
            shapeFuego.mesh = meshCasa.GetComponent<MeshFilter>().sharedMesh;

            colorFuego.enabled = true;
            Gradient grad = new Gradient();
            grad.SetKeys(
                new GradientColorKey[]
            {
                new GradientColorKey(new Color(1f, 0.78f, 0f), 0.08f), //amarillo
                new GradientColorKey(new Color(0.82f, 0.047f, 0f), 0.2f), //rojo
                new GradientColorKey(Color.black, 0.58f), //negro
            },
                new GradientAlphaKey[]
                {
                    new GradientAlphaKey(1f, 0.7f), //al 70% = opaco
                    new GradientAlphaKey(0.6f, 1f) //al final = casi transparente
                }
            );
            colorFuego.color = grad;

            sizeFuego.enabled = true;
            sizeFuego.y = new ParticleSystem.MinMaxCurve(1f, new AnimationCurve(
                    new Keyframe(0f, 0f),  // inicio de la vida
                    new Keyframe(0.5f, 1f),  // mitad de la vida
                    new Keyframe(1f, 0f)   // final de la vida
            ));
            sizeFuego.z = new ParticleSystem.MinMaxCurve(1f, new AnimationCurve(
                new Keyframe(0f, 0f),  // inicio de la vida
                new Keyframe(0.5f, 1f),  // mitad de la vida
                new Keyframe(1f, 0f)   // final de la vida
            ));

            //llamar a script audio y poner audio de quemandose

            fuego.Clear();
            fuego.Play();

            Debug.Log("Se ha cambiado el fuego pequeño a fuego casa");
        }
    }
    
    private void cleanChange(float numComprobador)
    {
        //activar o desactivar, que pille mesh de casas de manera random al estar a 70-80, y mientras haya pasado un tiempo sin acciones malas. Al bajar de 70 se las particulas clean desaparecen
        if (numComprobador > 70)
        {
            if (meshesCasas.Length > 0)
            {
                int index = Random.Range(0, meshesCasas.Length);
                shapeLimpio.shapeType = ParticleSystemShapeType.Mesh;
                shapeLimpio.mesh = meshesCasas[index].GetComponent<MeshFilter>().sharedMesh;
                Debug.Log("Hay una casa más limpia");
            }
        }
    }

}
