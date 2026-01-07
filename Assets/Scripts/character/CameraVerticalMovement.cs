using System;
using System.Security.Cryptography;
using UnityEngine;

public class CameraVerticalMovement : MonoBehaviour
{


    public float rotationSpeed = 100f; // velocidad de rotación
    public float minX = -45f;          // límite inferior total
    public float maxX = 45f;           // límite superior total

    private float currentX = 0f;       // rotación acumulada total

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        // Obtener entrada vertical (mouse Y)
        float verticalInput = Input.GetAxis("Mouse Y");

        // Acumular rotación
        currentX -= verticalInput * rotationSpeed * Time.deltaTime;

        // Limitar rotación total
        currentX = Mathf.Clamp(currentX, minX, maxX);

        // Aplicar rotación
        transform.localEulerAngles = new Vector3(
            currentX,
            transform.localEulerAngles.y,
            transform.localEulerAngles.z
        );
    }
    

}
