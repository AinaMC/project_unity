using System.Threading;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    CharacterController controller;
    InputHandler input;
    public float Speed = 0.1f;
    float lastvelocity_y;
    //Para Animator
    public Animator animator;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        input = GetComponent<InputHandler>();
    }
    void FixedUpdate()
    {
        Mover();
        // Pasar los valores al Animator
        animator.SetFloat("Vel_X", input.MoveInput.x);
        animator.SetFloat("Vel_Y", input.MoveInput.y);

    }
    private void Mover()
    {
        var velocity = new Vector3(input.MoveInput.x, 0, input.MoveInput.y) * Speed;
        controller.SimpleMove(velocity);
        //Cridem a Look At
        if (velocity.magnitude > 0.01f)
        {
            Turn(velocity);
        }
    }
    private void Turn(Vector3 dir)
    {
        Vector3 target = transform.position + dir;
        target.y = transform.position.y;
        transform.LookAt(target);
    }
}

