using UnityEngine;

public class npc_animations : MonoBehaviour
{
    [Header("Animaciones")]//dividir en el editor visualmente
    public Animation anim;
    public string caminandoAnim;
    
    void Start()
    {
        anim.Play(caminandoAnim);
    }

    void Update()
    {
        
    }
}
