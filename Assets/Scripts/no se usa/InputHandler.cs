using System;
using System.Diagnostics;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Vector3 MoveInput;
    public bool Jump;
    public event Action OnJumpButtonPressed;

    void Update()
    {

        MoveInput.x = Input.GetAxis("Horizontal");
        MoveInput.y = Input.GetAxis("Vertical");


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump = true;
            OnJumpButtonPressed?.Invoke();  // Invoca el evento cuando se presiona la tecla de salto
            UnityEngine.Debug.Log("Jump! " + Jump);
        }
        else
        {
            Jump = false;
        }

    }
}