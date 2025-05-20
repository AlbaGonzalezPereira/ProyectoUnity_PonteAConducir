using UnityEngine;

public class AmbulanciaSoundController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip motor;
    public AudioClip bocina;
    public AudioClip cesped;

    // M�todo que incluye el sonido del motor al arrancar

    public void arrancarMotor()
    {
        audioSource.PlayOneShot(motor);    
    }

    // M�todo que incluye el sonido del motor al chocar con la persona
    public void sonarBocina()
    {
        audioSource.PlayOneShot(bocina);
    }
    
    // M�todo que reproduce el sonido del motor al ir por el cesped en bucle
    public void sonarCespedEnBucle()
    {
        audioSource.clip = cesped;
        audioSource.loop = true;
        audioSource.Play();
    }

    // M�todo para detener el sonido del c�sped
    public void detenerCesped()
    {
        if (audioSource.isPlaying && audioSource.clip == cesped)
        {
            audioSource.Stop();
            audioSource.loop = false;
            audioSource.clip = null;
        }
    }
}
