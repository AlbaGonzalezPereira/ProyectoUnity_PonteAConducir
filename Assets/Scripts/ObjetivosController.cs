using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ObjetivosController : MonoBehaviour
{
    public TextMeshProUGUI textoObjetivos;

    private bool colegioCompletado = false;
    private bool gasolineraCompletado = false;
    private bool hospitalCompletado = false;

    // Método que se llama al inicio, solo una vez se llama
    void Start()
    {
        ActualizarTexto();
    }

    // Método que carga la escena de victoria después de 4 segundos
    private System.Collections.IEnumerator CargarVictoria()
    {
        yield return new WaitForSeconds(4f); // Esperamos 4 segundos antes de cargar la escena de victoria
        SceneManager.LoadScene("Victoria");
    }

    void Update()
    {
        if (colegioCompletado && gasolineraCompletado && hospitalCompletado)
        {
            Debug.Log("Todos los objetivos completados.");
            StartCoroutine(CargarVictoria()); // Cargamos la escena de victoria cuando los objetivos estén completos
        }
    }

    // método que que sirve para completar los objetivos
    public void CompletarObjetivo(string nombre)
    {
        Debug.Log($"Objetivo completado: {nombre}");
        switch (nombre)
        {
            case "Colegio":
                colegioCompletado = true;
                break;
            case "Gasolinera":
                gasolineraCompletado = true;
                break;
            case "Hospital":
                hospitalCompletado = true;
                break;
        }

        ActualizarTexto();
    }

    //Ponemos los objetivos (instrucciones) en la pantalla
    void ActualizarTexto()
    {
        textoObjetivos.text =
            $"Objetivos:\n" +
            $"Ir al colegio ({(colegioCompletado ? "1" : "0")}/1)\n" +
            $"Ir a la gasolinera ({(gasolineraCompletado ? "1" : "0")}/1)\n" +
            $"Ir al hospital ({(hospitalCompletado ? "1" : "0")}/1)";
    }
}
