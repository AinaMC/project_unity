using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class demonio_angel : MonoBehaviour
{
    [Header("Demonio")]
    public GameObject demonPrefab;
    private GameObject copia_demonio;
    public Transform sitioInstanciarDemonio;
    public bool isDemonHere;

    [Header("Angel")]
    public GameObject angelPrefab;
    private GameObject copia_angel;
    public Transform sitioInstanciarAngel;
    public bool isAngelHere;

    [Header("Mundo")]
    public WorldManagement mundo;


    private void Start()
    {
        //Demonio
        //sitioInstanciarDemonio.position = new Vector3(-2.67f, -23.43f, -5.42f);
        //sitioInstanciarDemonio.rotation = Quaternion.Euler(0, 0, 0);

        //Angel
        //sitioInstanciarAngel.position = new Vector3(-1.73f, -20.82f, 14.46f);
        //sitioInstanciarAngel.rotation = Quaternion.Euler(-90, 180, 92.33f);

        isDemonHere = true;
        isAngelHere = true;
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
            aparecerDemonio();
        }
        //Si vuelve al mundo normal tienen que desaparecer
        if (mundo.estatus_mundo() >= 15 && isAngelHere)
        {
            isAngelHere = false;
            eliminarAngel();
        }
        if (mundo.estatus_mundo() <= 85 && isDemonHere)
        {
            isDemonHere = false;
            eliminarDemonio();
        }
    }
    void aparecerAngel()
    {
        copia_angel = Instantiate(angelPrefab, sitioInstanciarAngel.position, sitioInstanciarAngel.rotation);
        copia_angel.transform.localScale = new Vector3(6.05f, 6.05f, 6.05f);
        Debug.Log("Un Angel ha aparecido");
        //EditorDialog.DisplayAlertDialog("Alguien ha aparecido", "Un Angel ha aparecido para ayudarte a volver al camino del bien", "Ok");

    }
    void aparecerDemonio()
    {
        copia_demonio = Instantiate(demonPrefab, sitioInstanciarDemonio.position, sitioInstanciarDemonio.rotation);
        Debug.Log("Un Demonio ha aparecido");
    }

    void eliminarAngel()
    {
        Destroy(copia_angel, 1);
        Debug.Log("El Angel se ha ido");
    }
    void eliminarDemonio()
    {
        Destroy(copia_demonio, 1);
        Debug.Log("El Demonio se ha ido");
    }

}
