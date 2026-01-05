using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movent_rigidbody : MonoBehaviour
{
    //Valores
    public float speed = 7f;
    public float rotationSpeed = 20f;
    //Quaternion targetRotation;

    public Rigidbody rb;
    public Vector3 movement;
    //public Vector3 rotate;
    //float rotacione;

    //Para Animator
    public Animator animator;
    private float x, y;


    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        //rotacione = (rotacione + x * 10) % 360f;

        movement = new Vector3(x, 0, y).normalized;
        //rotate = new Vector3(0, x, 0).normalized;
        //rb.MoveRotation(Quaternion.Euler(0, rotacione, 0));

        // Pasar los valores al Animator
        animator.SetFloat("Vel_X", x);
        animator.SetFloat("Vel_Y", y);
    }


    void FixedUpdate()
    {
        moveCharacter(movement);
        //var currentRotation = rb.rotation;
        //var newRotation = Quaternion.RotateTowards(currentRotation, targetRotation, anglePerSecond * Time.deltaTime);
        //float newRotation = (0, x * Time.deltaTime * rotationSpeed, 0);
        //rb.MoveRotation(newRotation);
    }


    void moveCharacter(Vector3 direction)
    {
        rb.linearVelocity = direction * speed;
        //rb.rotation = Quaternion.Euler(rotate);
    }

}