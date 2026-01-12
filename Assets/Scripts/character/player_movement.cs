using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    [Header("Variables")]
    public float runSpeed = 10f;
    public float rotationSpeed = 20f;
    public float jumpForce; //Cambiar este en mov
    private float x, y;

    [Header("Anim y Mov")]
    public LayerMask groundLayer;
    public Animator animator;
    private InputHandler _inputHandler;
    private Rigidbody rb;
    private bool isGrounded;
    public WorldManagement mundo;


    void Start()
    {
        // Obtener la referencia del InputHandler
        _inputHandler = GetComponent<InputHandler>();
        rb = GetComponent<Rigidbody>();
        jumpForce = 20f;
    }

    void Update()
    {
        // Obtener los valores de movimiento desde InputHandler
        x = _inputHandler.MoveInput.x;  // Horizontal (movimiento de izquierda/derecha)
        y = _inputHandler.MoveInput.y;  // Vertical (movimiento hacia adelante/atr�s)

        isGrounded = CheckGrounded();

        if (isGrounded && _inputHandler.Jump )
        {

            Jump();
        }

        // Detectar si el jugador está en el suelo y aplicar la gravedad adicional si no lo está
        if (!isGrounded && rb.linearVelocity.y < 0)  // Si el jugador está cayendo
        {
            rb.AddForce(Vector3.down * (jumpForce + 9.81f), ForceMode.Acceleration);
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

        float mundo_actual = mundo.estatus_mundo();
        change_Jump(mundo_actual);
    }
    void change_Jump(float x)
    {

            jumpForce = x - 10;

    }
    // Metodo para cambiar la velocidad de movimiento
    public void cambiar_vel(float new_vel)
    {
        runSpeed = new_vel;
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        animator.SetTrigger("isJump");
    }

    private bool CheckGrounded()
    {

        Collider _collider = GetComponent<Collider>();

        Vector3 rayOrigin = _collider.bounds.center - Vector3.up * 0.5f;

        bool grounded = Physics.Raycast(rayOrigin, Vector3.down, 1f, groundLayer);

        Debug.DrawRay(rayOrigin, Vector3.down * 1f, grounded ? Color.green : Color.red);
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