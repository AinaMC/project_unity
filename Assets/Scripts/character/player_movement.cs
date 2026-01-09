using UnityEngine;


public class player_movement : MonoBehaviour
{
    //Variables
    private InputHandler _inputHandler;
    public Animator animator;
    private Rigidbody rb;


    public float runSpeed = 7f;
    public float rotationSpeed = 20f;

    private float x, y;

    public LayerMask groundLayer;
    private bool isGrounded;
    private float _jumpForce = 16f;

    private void Awake()
    {
        _inputHandler = GetComponent<InputHandler>();
        rb = GetComponent<Rigidbody>();

    }

    void Start()
    {

    }

    void Update()
    {
        // Obtener los valores de movimiento desde InputHandler
        x = _inputHandler.MoveInput.x;  // Horizontal (movimiento de izquierda/derecha)
        y = _inputHandler.MoveInput.y;  // Vertical (movimiento hacia adelante/atrás)

        isGrounded = CheckGrounded();

        if (isGrounded && _inputHandler.Jump)
        {
            Jump();
        }

        // Detectar si el jugador está en el suelo y aplicar la gravedad adicional si no lo está
        if (!isGrounded && rb.linearVelocity.y < 0)  // Si el jugador está cayendo
        {
            rb.AddForce(Vector3.down * 16f, ForceMode.Acceleration);  // Añade gravedad manualmente
        }

        if ( x!= 0 )
        {
            RotateCharacter(x);
        }

        if ( y != 0 )
        {
            MoveCharacter(y);
        }

        // Pasar los valores de movimiento al Animator
        animator.SetFloat("Vel_X", x);
        animator.SetFloat("Vel_Y", y);
    }

    public void cambiar_vel(float new_vel)
    {
        runSpeed = new_vel;
    }

    private void Jump()
    {
        Debug.Log("Jump!");
        rb.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
    }

    private bool CheckGrounded()
    {
        //return Physics.Raycast(transform.position, Vector3.down, f, groundLayer);

        bool grounded = Physics.Raycast(transform.position, Vector3.down, 0.25f, groundLayer);
        Debug.DrawRay(transform.position, Vector3.down * 0.25f, grounded ? Color.green : Color.red); // Muestra el raycast en la escena
        return grounded;
    }

    private void RotateCharacter(float horizontalInput)
    {
        float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;

        Quaternion deltaRotation = Quaternion.Euler(0f, rotationAmount, 0f);

        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    private void MoveCharacter(float verticalInput)
    {
        Vector3 moveDirection = transform.forward * y;
        rb.MovePosition(rb.position + moveDirection * runSpeed * Time.deltaTime);
    }
}