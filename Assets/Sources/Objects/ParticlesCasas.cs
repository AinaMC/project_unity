using UnityEngine;

public class ParticlesControler : MonoBehaviour
{
    public WorldManagement contador; //llamando al script WorldManagement -->
    private float comprobador;

    ParticleSystem fuego = GameObject.Find("Fuego").GetComponent<ParticleSystem>();

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
            fireChange(comprobador);
        }
    }

    private void fireChange(float numComprobador)
    {
        //fuego.startSpeed = 5f;
    }
}
