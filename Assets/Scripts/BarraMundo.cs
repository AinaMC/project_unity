using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class BarraMundo : MonoBehaviour
{
    public WorldManagement mundo;
    public Image barra_mundo;

     float mundoActual;
     //float mundoMax = 100;

    void Start()
    {
        mundoActual = mundo.estatus_mundo();
        barra_mundo.fillAmount = mundoActual / 100f;
    }
    void Update()
    {
        mundoActual = mundo.estatus_mundo();

        barra_mundo.fillAmount = mundoActual / 100f;
    }
}
