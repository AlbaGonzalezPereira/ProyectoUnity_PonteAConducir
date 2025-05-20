using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesInicioScript : MonoBehaviour
{
    public string nombreEscenaSiguiente; // Nombre de la escena a cargar  

    // Por si queremos implementar el metodo jugar
    //public void Jugar()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}

    // Método que nos permite salir del juego
    public void Salir()
    {
        Application.Quit();
        Debug.Log("Salir");
    }

    // Método que nos permite cargar una escena
    public void IrScene()
    {
        // Cargamos la escena
        SceneManager.LoadScene(nombreEscenaSiguiente);
    }
}
