using UnityEngine;
using UnityEngine.UI;

public class MedallaController : MonoBehaviour
{
    public Sprite bronceSprite;
    public Sprite plataSprite;

    public Image medallaImage;

    // Contador de medallas ganadas
    private int medallasGanadas = 0;

    void Start()
    {
        medallaImage.gameObject.SetActive(false); // Ocultamos al inicio
    }

    public void MostrarSiguienteMedalla()
    {
        medallasGanadas++;

        medallaImage.gameObject.SetActive(true); // Mostramos la medalla

        if (medallasGanadas == 1)
            medallaImage.sprite = bronceSprite; // Mostramos la medalla de bronce
        else if (medallasGanadas == 2)
            medallaImage.sprite = plataSprite; // Mostramos la medalla de plata
        else
            Debug.Log("Ya se han mostrado todas las medallas.");
    }
}
