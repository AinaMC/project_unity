using UnityEngine;

public class dragon : MonoBehaviour
{
    //ir al rigidbody???
    private Rigidbody _rigidbody;

    public void Launch(float speed)
    {
        _rigidbody = GetComponent<Rigidbody>();
       // _rigidbody.velocity = transform.forward * speed;
    }

}
