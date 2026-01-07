using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Vector3 MoveInput;  // Store the horizontal and vertical input as a Vector3
    public bool Jump;  // To track if the player presses the jump key

    void Update()
    {
        // Get input for horizontal and vertical axes (e.g., A/D, W/S, Arrow keys, or joystick axes)
        MoveInput.x = Input.GetAxis("Horizontal");
        MoveInput.y = Input.GetAxis("Vertical");

        // You can add more inputs for jump or other actions
        Jump = Input.GetKeyDown(KeyCode.Space);  // Check if the spacebar is pressed

        if (Jump)
        {
            Debug.Log("Spacebar Pressed");
        }
    }
}