//using System.Diagnostics.CodeAnalysis;
//using Unity.VisualScripting;
//using UnityEngine;

//[RequireComponent(typeof(AudioSource))]
//public class AudioManagment : MonoBehaviour
//{
//    [SerializeField] private AudioClip[] audios; //array en donde cada elemento será un clip de audio

//    private AudioSource controlAudio; //llamada al AudioSource (componente de control del audio)
//    public WorldManagement contador; //llamando al script Text_Contador
//    private int comprobador;
//    private AudioListener escuchar;
//    private void Start()
//    {
//        controlAudio = GetComponent<AudioSource>();
//        Debug.Log("Audio cosas");
//        comprobador = contador.estatus_mundo;
//        SeleccionAudio(2, 0.2f);
//        escuchar = GetComponent<AudioListener>();
//    }
//    private void Update()
//    {
//        if (comprobador !=contador.estatus_mundo)
//        {
//            comprobador = contador.estatus_mundo;
//            changeAudio(comprobador);
//        }

//    }

//    //gestion de todos los audios
//    public void SeleccionAudio(int indice, float volumen) //creamos variable para el num del array (para escojer el elemento con su audio) y otra para el volumen (este puede ser de 0-1)
//    {
//        controlAudio.PlayOneShot(audios[indice], volumen);
//    }
//    private void changeAudio(int numComprobador)
//    {
//        if (escuchar == true)
//        {
//            controlAudio.Stop();
//        }
//        //si el contador tiene + de (o =) 70 puntos
//        if (numComprobador >= 70)
//        {
            
//            //Element 1 - Utopia
//            SeleccionAudio(1, 0.2f); //me detecta el numero como double??? así que le pongo explicitamente que se trata de un float
//            Debug.Log("Reproduciendo: UTOPIA");
//        }
//        //si el contador tiene - de (o =) 30 puntos
//        else if (numComprobador <= 30)
//        {
            
//            //Element 0 - Distopia
//            SeleccionAudio(0, 0.3f); //distopia esta (el audio org esta mas bajo)
//            Debug.Log("Reproduciendo: DISTOPIA");
//        }
//        else
//        {
            
//            //Element 2 - Neutro
//            SeleccionAudio(2, 0.2f);
//            Debug.Log("Reproduciendo: NEUTRO");
//        }
//    }
//}
