using UnityEngine;

public class HealingFresnel : MonoBehaviour
{
    Renderer renderer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponent<Renderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        renderer.material.SetFloat("_intensity", 1);
    }
}
