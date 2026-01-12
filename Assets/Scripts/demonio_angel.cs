using UnityEngine;

public class demonio_angel : MonoBehaviour
{
    [Header("Demonio")]
    public GameObject demonPrefab;
    public Transform sitioInstanciarDemonio;
    bool isDemonHere;

    [Header("Angel")]
    public GameObject angelPrefab;
    public Transform sitioInstanciarAngel;
    bool isAngelHere;

    [Header("Mundo")]
    public WorldManagement mundo;

    private void Start()
    {
        //Demonio
        //sitioInstanciarDemonio.position = new Vector3(-134.52f, 0.245f, -43.56f);
        //sitioInstanciarDemonio.rotation = Quaternion.Euler(0, 66, 0);

        //Angel
        //sitioInstanciarAngel.position = new Vector3(-134.52f, 0.245f, -43.56f);
        //sitioInstanciarAngel.rotation = Quaternion.Euler(0, 66, 0);

        isDemonHere = false;
        isAngelHere = false;
    }

    void FixedUpdate()
    {
        //Si esta en distopico 15 aparece el angel
        if (mundo.estatus_mundo() < 15 && !isAngelHere)
        {
            isAngelHere = true;
            aparecerAngel();
        }
        //Si esta en utopico 15 aparece el demonio
        if (mundo.estatus_mundo() > 85 && !isDemonHere)
        {
            isDemonHere = true;
            aparecerAngel();
        }
        //Si vuelve al mundo normal tienen que desaparecer
        if (mundo.estatus_mundo() > 15)
        {
            //isDragonHere = false;
            //eliminar();
        }
    }
    void aparecerAngel()
    {
       // var angelito = Instantiate(dragonPrefab, sitioInstanciarAngel.position, sitioInstanciarAngel.rotation);
    }
    void aparecerDemonio()
    {
        //var demoncete = Instantiate(dragonPrefab, sitioInstanciarDemonio.position, sitioInstanciarDemonio.rotation);
    }

    //void eliminarAngel()
    //{

    //}
    //void eliminarDemonio()
    //{

    //}

}
