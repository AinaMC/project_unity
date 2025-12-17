using System.Threading;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Texto_Contador mundo;
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
        //Viento
        //Utopico (favor) --> 1-20
        if (mundo.estatus_mundo() >= 1 && mundo.estatus_mundo() <= 20)
        {

        }
        //Distopico (en contra) --> 80-100
        else if (mundo.estatus_mundo() >= 80 && mundo.estatus_mundo() <= 100)
        {

        }
    }
    private void Move()
    {
        var velocity = new Vector3(input.MoveInput.x, 0, input.MoveInput.y) * Speed;
        //controller.SimpleMove(velocity);
        velocity += external_force;
        controller.SimpleMove(velocity);


    }
}

