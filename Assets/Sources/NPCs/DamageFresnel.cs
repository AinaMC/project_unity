using System.Collections;
using UnityEngine;

public class DamageFresnel : MonoBehaviour
{
    //Renderer renderer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
    //    renderer = GetComponent<Renderer>();
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    renderer.material.SetFloat("_intensity", 1);
    //    renderer.material.SetColor("_Color", DamageColor);
    //}

    //UPDATED -->
    Renderer rend;
    Material mat;
    public Color DamageColor = new Color(0.6509434f, 0, 0);
    public Color HealColor = new Color(0, 0.6509434f, 0);

    void Start()
    {
        rend = GetComponent<Renderer>();
        mat = rend.material;

        // Apaguem el fresnel al començar
        mat.SetFloat("_Intensity", 0f);
    }

    public void Damage()
    {
        mat.SetColor("_Color", DamageColor);
        StartCoroutine(FresnelTemporal());

        //WorldManagement.Instance.AfegirPunts(-10);
    }

    public void Heal()
    {
        mat.SetColor("_Color", Color.green);
        StartCoroutine(FresnelTemporal());

        //WorldManagement.Instance.AfegirPunts(10);
    }

    IEnumerator FresnelTemporal()
    {
        mat.SetFloat("_Intensity", 1f);
        yield return new WaitForSeconds(0.5f);
        mat.SetFloat("_Intensity", 0f);
    }

}
