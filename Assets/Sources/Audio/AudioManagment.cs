using UnityEngine;

public class AudioManagment : MonoBehaviour
{
    [SerializeField] private AudioClip[] audios; //array en donde cada elemento será un clip de audio

    private AudioSource controlAudio; //llamada al AudioSource (componente de control del audio)
    public Texto_Contador contador; //llamando al script Text_Contador

    private void Awake()
    {
        controlAudio.GetComponent<AudioSource>();
    }

    //gestion de todos los audios
    public void SeleccionAudio(int indice, float volumen) //creamos variable para el num del array (para escojer el elemento con su audio) y otra para el volumen (este puede ser de 0-1)
    {
        controlAudio.PlayOneShot(audios[indice], volumen);
    }
    private void Update()
    {
        //si el contador tiene + de (o =) 70 puntos
        if (contador.puntos_globales >= 70)
        {
            //Element 1 - Utopia
            SeleccionAudio(1, 1); //me detecta el numero como double??? así que le pongo explicitamente que se trata de un float
            Debug.Log("Reproduciendo: UTOPIA");
        }
        //si el contador tiene - de (o =) 30 puntos
        else if (contador.puntos_globales <= 30)
        {
            //Element 0 - Distopia
            SeleccionAudio(0, 1);
            Debug.Log("Reproduciendo: DISTOPIA");
        }
        else
        {
            //Element 2 - Neutro
            SeleccionAudio(2, 1);
            Debug.Log("Reproduciendo: NEUTRO");
        }
    }
}
