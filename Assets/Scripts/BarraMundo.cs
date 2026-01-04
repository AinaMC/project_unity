using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public WorldManagement mundo;
    public Image barra_mundo;

     float mundoActual;
     float mundoMax = 100;

    void start()
    {
        mundoActual = (float)mundo.estatus_mundo();
    }
    void Update()
    {
        mundoActual = (float)mundo.estatus_mundo();

        barra_mundo.fillAmount = mundoActual / mundoMax;
    }
}
