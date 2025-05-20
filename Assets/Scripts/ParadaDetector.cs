using System.Collections.Generic;
using UnityEngine;

public class ParadaDetector : MonoBehaviour
{
    public string tagObjetivo = "Coche";
    public string nombreParada = ""; // El nombre de la parada se pasa en el IDE
    public GameObject objetivos;
    public GameObject medallas;
    private float tiempoEncima = 0f;
    private float tiempoRequerido = 2f;
    private static HashSet<string> paradasCompletadas = new HashSet<string>();

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(tagObjetivo))
        {
            tiempoEncima += Time.deltaTime;

            if (tiempoEncima >= tiempoRequerido)
            {
                if (!paradasCompletadas.Contains(nombreParada)) //preguntamos si contiene la parada
                {
                    Debug.Log("Coche estuvo 2 segundos en la parada: " + nombreParada);

                    paradasCompletadas.Add(nombreParada); // añadimos la parada

                    objetivos.GetComponent<ObjetivosController>().CompletarObjetivo(nombreParada);

                    medallas.GetComponent<MedallaController>().MostrarSiguienteMedalla();
                }
                else
                {
                    Debug.Log("Ya se completó esta parada: " + nombreParada);
                }

                tiempoEncima = 0f; // reiniciamos el tiempo
            }
        }
    }

    //Trigger para reiniciar el tiempo al salir de la parada
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(tagObjetivo))
        {
            tiempoEncima = 0f; 
        }
    }

    
}
