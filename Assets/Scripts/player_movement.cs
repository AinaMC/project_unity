using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float runSpeed = 7f; 
    public float rotationSpeed = 250f; 
    public Animator animator;
    private float x, y;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        // Rotación
        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);

        // Movimiento
        transform.Translate(0, 0, y * Time.deltaTime * runSpeed);

        // Pasar los valores al Animator
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
