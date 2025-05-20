using UnityEngine;
using UnityEngine.SceneManagement;
public class PausaJuego : MonoBehaviour
{
    public GameObject menuPausa; // Asignamos el objeto del men� de pausa
    public bool pausado = false; // Variable para controlar el estado de pausa
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) // Si se presiona la tecla Escape
        {
            if (pausado) // Si el juego est� pausado
            {
                ReanudarJuego(); // Llamamos a la funci�n para reanudar el juego
            }
            else
            {
                PausarJuego(); // Llamamos a la funci�n para pausar el juego
            }
        }

    }

    public void ReanudarJuego()
    {
        Time.timeScale = 1f; // Reanudamos el tiempo del juego
        menuPausa.SetActive(false); // Desactivamos el men� de pausa
        pausado = false; // Cambiamos el estado de pausa a falso
    }

    public void PausarJuego()
    {
        Time.timeScale = 0f; // Pausamos el tiempo del juego
        menuPausa.SetActive(true); // Activamos el men� de pausa
        pausado = true; // Cambiamos el estado de pausa a verdadero
    }
    public void IrMenuPrincipal()
    {
        ReanudarJuego();//Reanudamos el juego antes de cambiar de escena
        SceneManager.LoadScene("InicioScene");//Cargamos inicio
    }

}
