using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    //Variables
    public float runSpeed = 7f; // Velocidad de movimiento
    public float rotationSpeed = 20f; // Velocidad de rotación
    public float jumpForce = 5f;
    private float x, y;

    public LayerMask groundLayer;

    public Animator animator; // Referencia al Animator
    private InputHandler _inputHandler; // Referencia al script InputHandler
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        // Obtener la referencia del InputHandler
        _inputHandler = GetComponent<InputHandler>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Obtener los valores de movimiento desde InputHandler
        x = _inputHandler.MoveInput.x;  // Horizontal (movimiento de izquierda/derecha)
        y = _inputHandler.MoveInput.y;  // Vertical (movimiento hacia adelante/atrás)

        isGrounded = CheckGrounded();

        //Debug.Log("Is Grounded: " + isGrounded);

        //if (_inputHandler.Jump && isGrounded)
        //{
        //    Jump();
        //}

        if( x!= 0 )
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

    // Método para cambiar la velocidad de movimiento
    public void cambiar_vel(float new_vel)
    {
        runSpeed = new_vel;
    }

    //private void Jump()
    //{
    //    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    //}

    private bool CheckGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 2f, groundLayer);
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