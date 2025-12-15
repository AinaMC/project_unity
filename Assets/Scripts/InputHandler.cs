using System.Collections.Specialized;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Vector2 MoveInput;

    void Start()
    { }
    //En el input tenim 2, el X y Y, despres ho cridem com a clase
    void Update()
    {
        MoveInput.x = Input.GetAxis("Horizontal");
        MoveInput.y = Input.GetAxis("Vertical");
    }
    public Vector3 GetInputInPlane()
    {
        return new Vector3(MoveInput.x, 0, MoveInput.y);
    }
}
