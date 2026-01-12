using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AudioManagment : MonoBehaviour
{
    //private static AudioManagment instance;

    [SerializeField] private AudioClip[] audios; //array en donde cada elemento será un clip de audio

    private AudioSource audioA, audioB;
    private AudioSource controlAudio; //llamada al AudioSource (componente de control del audio)

    public WorldManagement contador; //llamando al script WorldManagement
    private float comprobador;
    //private void Awake()
    //{
    //    instance = this;
    //}
    private void Start()
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        audioA = sources[0];
        audioB = sources[1];

        controlAudio = audioA;

        controlAudio.clip = audios[2]; // Neutro
        controlAudio.volume = 0.2f;
        controlAudio.Play();
        Debug.Log("Audio cosas ha empezado. Reproduciendo: Neutro");

        comprobador = contador.estatus_mundo();
    }
    private void Update()
    {
        if (comprobador != contador.estatus_mundo())
        {
            comprobador = contador.estatus_mundo();
            changeAudio(comprobador);
        }
    }

    //crossfade
    IEnumerator Crossfade(int nuevoIndice, float volumenObjetivo, float duracion)
    {
        AudioSource entrante = (controlAudio == audioA) ? audioB : audioA;
        AudioSource saliente = controlAudio;

        entrante.clip = audios[nuevoIndice];
        entrante.volume = 0f;
        entrante.Play();

        float t = 0f;

        while (t < duracion)
        {
            t += Time.deltaTime;
            float lerp = t / duracion;

            entrante.volume = Mathf.Lerp(0f, volumenObjetivo, lerp);
            saliente.volume = Mathf.Lerp(volumenObjetivo, 0f, lerp);

            yield return null;
        }

        saliente.Stop();
        controlAudio = entrante;
    }

    private void changeAudio(float numComprobador)
    {
        int indiceDeseado;
        float volumen;

        if (numComprobador >= 70) // Utopía
        {
            indiceDeseado = 1;
            volumen = 0.2f;

        }
        else if (numComprobador <= 30) // Distopía
        {
            indiceDeseado = 0;
            volumen = 0.3f;
        }
        else // Neutro
        {
            indiceDeseado = 2;
            volumen = 0.2f;
        }

        // Si ya está sonando ese clip, no hacemos nada
        if (controlAudio.clip == audios[indiceDeseado])
        {
            return;
        }

        //inicializa el crossfade
        StartCoroutine(Crossfade(indiceDeseado, volumen, 2.3f)); //crossfade con indice, volumen y duración del crossfade
    }
    
    //public void playSound(int index, float volume = 1)
    //{
    //    instance.controlAudio.PlayOneShot(instance.audios[index]);
    //}
}
