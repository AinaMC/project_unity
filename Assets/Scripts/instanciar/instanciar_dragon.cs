using UnityEngine;

public class instanciar_dragon : MonoBehaviour
{
    [Header("Dragon")]
    public GameObject dragonPrefab;
    private GameObject copia_dragon;
    public Transform sitioInstanciarDragon;
    bool isDragonHere;
    public WorldManagement mundo;

    private void Start()
    {
        //sitioInstanciar.position = new Vector3 (-134.52f, 0.245f, -43.56f);
        //sitioInstanciar.rotation = Quaternion.Euler (0, 66, 0);
        isDragonHere = false;
    }
    
    void FixedUpdate()
    {
        if (mundo.estatus_mundo() <= 15 && !isDragonHere)
        {
            isDragonHere = true;
            aparecer();
        }
        if (mundo.estatus_mundo() > 15 && isDragonHere)
        {
            isDragonHere=false;
            eliminar();
        }
    }
    void aparecer()
    {
        copia_dragon = Instantiate(dragonPrefab, sitioInstanciarDragon.position, sitioInstanciarDragon.rotation);
        Debug.Log("Un DRAGON ha aparecido");
    }

    void eliminar()
    {
        Destroy(copia_dragon, 1);
        Debug.Log("El Dragon se ha ido");
    }

}
