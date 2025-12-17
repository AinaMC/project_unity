using UnityEngine;

public class Viento : MonoBehaviour
{
    public Texto_Contador mundo;
    Vector3 external_Force = new Vector3 (10, 0, 0);

    //Viento a Favor o en Contra
    //Neutral --> 21-79
    //Utopico (favor) --> 1-20
    //Distopico (en contra) --> 80-100
    void Start()
    {
        
    }


    void Update()
    {
        //Utopico (favor) --> 1-20
        if ( mundo.estatus_mundo() >= 1 && mundo.estatus_mundo() <= 20)
        {

        }
        //Distopico (en contra) --> 80-100
        else if (mundo.estatus_mundo() >= 80 && mundo.estatus_mundo() <= 100)
        {

        }
    }
}
