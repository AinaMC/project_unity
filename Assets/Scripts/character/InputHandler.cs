using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [Header("Mov normal")]
    public Vector3 MoveInput;  // Store the horizontal and vertical input as a Vector3
    public bool Jump;  // To track if the player presses the jump key

    [Header("Mundo")]
    public WorldManagement mundo;
    private float lastContador;
    private float mundo_actual;

    private string horizontalInput = "Horizontal";
    private string verticalInput = "Vertical";
    private KeyCode jumpKey = KeyCode.Space;

    private void Start()
    {
        lastContador = 0;
        mundo_actual = mundo.estatus_mundo();
        AssignControlsBaseOnWorld();

    }

    void Update()
    {
        float mundo_actual = mundo.estatus_mundo();

        if (mundo_actual != lastContador)
        {
            lastContador = mundo_actual;
            AssignControlsBaseOnWorld();
        }

        // Get input for horizontal and vertical axes (e.g., A/D, W/S, Arrow keys, or joystick axes)
        MoveInput.x = Input.GetAxis(horizontalInput);
        MoveInput.y = Input.GetAxis(verticalInput);

        //Salto
        Jump = Input.GetKeyDown(KeyCode.Space); 
        //Mirar si barra espaciadora esta activada
        if (Jump)
        {
            Debug.Log("Spacebar Pressed");
        }

        mundo_actual = mundo.estatus_mundo();

    }
    //Assignar diferentes controles dependiendo del mundo
    private void AssignControlsBaseOnWorld()
    {
        mundo_actual = mundo.estatus_mundo();

        //Mundo normal
        if (mundo_actual == 50 )
        {
            horizontalInput = "Horizontal";  // Mantener controles estándar
            verticalInput = "Vertical";  // Mantener controles estándar
            jumpKey = KeyCode.Space;  // Dejar la tecla de salto en Space (común)

            Debug.Log("Controles asignados para mundo neutral");

        }
        else if (mundo_actual > 50) //Mundo utopico
        {
            Debug.Log("Utopico");
        }
        else if (mundo_actual < 50) //Mundo distopico
        {
            Debug.Log("Distopico");

        }
    }
}