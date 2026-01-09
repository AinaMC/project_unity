using UnityEngine;

public class ControlAstroVisual : MonoBehaviour
{
    public float distance = 1000.0f;
    public float scale = 15.0f;
    
void Start()
    { 
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, distance);
        transform.localScale = new Vector3(scale, scale, scale);
    }
    
    //public float distance = 1000f;
    //public float scale = 100f;
    //void Start()
    //{
    //    transform.localPosition = new Vector3(0, 0, distance);
    //    transform.localScale = Vector3.one * scale;
    //    //transform.localRotation = Quaternion.Euler(0, 180, 0);
    //}
    //void LateUpdate()
    //{
    //    if (Camera.main != null)
    //        transform.LookAt(Camera.main.transform);
    //}
}
