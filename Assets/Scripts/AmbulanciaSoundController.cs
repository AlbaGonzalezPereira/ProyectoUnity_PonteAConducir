using UnityEngine;

public class AmbulanciaSoundController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip motor;
    public AudioClip bocina;
    public AudioClip cesped;

    // Método que incluye el sonido del motor al arrancar

    public void arrancarMotor()
    {
        audioSource.PlayOneShot(motor);    
    }

    // Método que incluye el sonido del motor al chocar con la persona
    public void sonarBocina()
    {
        audioSource.PlayOneShot(bocina);
    }
    
    // Método que reproduce el sonido del motor al ir por el cesped en bucle
    public void sonarCespedEnBucle()
    {
        audioSource.clip = cesped;
        audioSource.loop = true;
        audioSource.Play();
    }

    // Método para detener el sonido del césped
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
