using System.Threading;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    CharacterController controller;
    InputHandler input;
    public float Speed = 4.2f;

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
        controller.SimpleMove(velocity);

    }
}

