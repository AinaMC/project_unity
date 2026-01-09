using UnityEngine;

public class DamageFresnel : MonoBehaviour
{
    Renderer renderer;
    public Color DamageColor = new Color(0.6509434f, 0, 0);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponent<Renderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        renderer.material.SetFloat("_intensity", 1);
        renderer.material.SetColor("_Color", DamageColor);
    }
}
