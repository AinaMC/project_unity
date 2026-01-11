using UnityEngine;

public class instanciar_dragon : MonoBehaviour
{
    public dragon dragonPrefab;
    public Transform sitioInstanciar;
    public WorldManagement mundo;
    bool isDragonHere;

    private void Start()
    {
        sitioInstanciar.position = new Vector3 (-134.52f, 0.245f, -43.56f);
        sitioInstanciar.rotation = Quaternion.Euler (0, 66, 0);
        isDragonHere = false;
    }
    
    void FixedUpdate()
    {
        if (mundo.estatus_mundo() < 10 && !isDragonHere)
        {
            isDragonHere = true;
            aparecer();
        }
        if (mundo.estatus_mundo() > 10 && isDragonHere)
        {
            isDragonHere=false;
            //eliminar();
        }
    }
    public void aparecer()
    {
        var dragoncete = Instantiate(dragonPrefab, sitioInstanciar.position, sitioInstanciar.rotation);
    }

    //public void eliminar()
    //{

    //}

}
