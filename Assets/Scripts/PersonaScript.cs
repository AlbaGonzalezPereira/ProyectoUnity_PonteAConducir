using UnityEngine;

public class PersonaScript : MonoBehaviour
{
    public Vector2 posicion1;
    public Vector2 posicion2;
    public Vector2 posicion3;
    public Vector2 posicion4;
    public float velocidad = 2f;

    private Animator animator;//para cargar las animaciones de la persona
    private Vector2[] posiciones;
    private int indiceActual = 0;
    private bool die = false;

    void Start()
    {
        animator = GetComponent<Animator>();//cogemos el componente animator de la persona

        // Guardamos las posiciones de donde va a ir en un array
        posiciones = new Vector2[] { posicion1, posicion2, posicion3, posicion4 };
    }

    void Update()
    {
        if (die)
            return;

        Vector2 objetivo = posiciones[indiceActual];

        // Calculamos la dirección hacia el lugar donde se dirige
        Vector2 direccion = (objetivo - (Vector2)transform.position).normalized;

        // Rotamos el sprite en la horizontal para que voltee
        if (Mathf.Abs(direccion.x) > 0.01f)
        {
            Vector3 escala = transform.localScale;
            escala.x = direccion.x > 0 ? Mathf.Abs(escala.x) : -Mathf.Abs(escala.x);
            transform.localScale = escala;
        }

        // Movemos hacia la siguiente posición
        transform.position = Vector2.MoveTowards(transform.position, objetivo, velocidad * Time.deltaTime);

        if (Vector2.Distance(transform.position, objetivo) < 0.01f)
        {
            indiceActual = (indiceActual + 1) % posiciones.Length;
        }
    }

    // Método que se activa cuando hay una colisión
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ambulance")
        {
            Debug.Log("Atropellaste a la persona");
            animator.SetTrigger("die");//cambiamos la animacion a muerte
            die = true;
        }
    }

    public void SetMuerto()
    {
        
    }
}
