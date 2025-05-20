using UnityEngine;
using UnityEngine.UI;

public class AjustesScript : MonoBehaviour
{
    public Slider sliderVelocidad;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sliderVelocidad.value = PlayerPrefs.GetFloat("carSpeed", 6f); // Recogemos el valor del slider guardado en PlayerPrefs, si no existe se inicializa a 6f
        GameData.carSpeed = sliderVelocidad.value; // Inicializamos la velocidad del coche con el valor guardado
    }

    public void CambiarVelocidad(float valor)
    {
        GameData.carSpeed = valor; // Cambiamos la velocidad del coche
        PlayerPrefs.SetFloat("carSpeed", valor);  // Guardamos el valor
        PlayerPrefs.Save();  // Confirmamos el valor a guardar

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
