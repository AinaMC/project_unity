using System.Threading;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    CharacterController controller;
    InputHandler input;
    public float Speed = 4.2f;
    Vector3 external_force = new Vector3(10, 0, 0);

    void Start()
    {
        controller = GetComponent<CharacterController>();
        input = GetComponent<InputHandler>();
    }
    void Update()
    {
        Move();        
        
    }
    private void Move()
    {
        var velocity = new Vector3(input.MoveInput.x, 0, input.MoveInput.y) * Speed;
        //controller.SimpleMove(velocity);
        velocity += external_force;
        controller.SimpleMove(velocity);


    }
}

