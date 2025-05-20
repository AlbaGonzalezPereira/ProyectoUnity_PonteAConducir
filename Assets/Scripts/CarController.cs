using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public enum controlMode
{
    KeyBoard, Touch
}

public class CarController : MonoBehaviour
{
    public AmbulanciaSoundController soundController;
    public controlMode CarControlMode;

    public float MaxSpeed = 7.0f;
    public float MaxSteer = 2.0f;
    public float Breaks = 0.2f;
    bool estabaEnMovimiento = false;

    [SerializeField]
    float Acceleration = 0.0f;
    float Steer = 0.0f;

    bool AccelFwd, AccelBwd;
    bool TouchAccel, TouchBack, TouchBreaks;
    bool SteerLeft, SteerRight;
    private float velocidadUpdate;
    public float Velocidad { get { return Acceleration; } set { Acceleration = value; } } // Propiedad para acceder a la velocidad
                                                                                          // Start is called before the first frame update
    void Awake()
    {
        //PlayerPrefs.DeleteAll(); // Uncomment this line to reset PlayerPrefs
    }
    void Start()
    {
        MaxSpeed = PlayerPrefs.GetFloat("carSpeed", 6f); // Cambiamos la velocidad del coche
        velocidadUpdate = MaxSpeed; // Guardamos la velocidad inicial
    }

    void FixedUpdate()
    {
        //Debug.Log("Velocidad: " + PlayerPrefs.GetFloat("carSpeed", 6f));
        bool enMovimiento = Mathf.Abs(Acceleration) > 0.01f;

        if (enMovimiento && !estabaEnMovimiento)
        {
            Debug.Log("Comenzó a moverse");
            soundController.arrancarMotor(); // Solo se llama una vez cuando empieza
        }
        else if (!enMovimiento && estabaEnMovimiento)
        {
            Debug.Log("Se detuvo");
        }

        estabaEnMovimiento = enMovimiento;
        if (CarControlMode == controlMode.KeyBoard)
        {
            if (Input.GetKey(KeyCode.UpArrow))
                Accel(1);                                                   //Accelerate in forward direction
            else if (Input.GetKey(KeyCode.DownArrow))
                Accel(-1);                                                  //Accelerate in backward direction
            else if (Input.GetKey(KeyCode.Space))
            {
                if (AccelFwd)
                    StopAccel(1, Breaks);                                   //Breaks while in forward direction
                else if (AccelBwd)
                    StopAccel(-1, Breaks);                                  //Breaks while in backward direction
            }
            else
            {
                if (AccelFwd)
                    StopAccel(1, 0.1f);                                 //Applies breaks slowly if no key is pressed while in forward direction
                else if (AccelBwd)
                    StopAccel(-1, 0.1f);                                    //Applies breaks slowly if no key is pressed while in backward direction
            }
        }

        if (CarControlMode == controlMode.Touch)
        {
            if (TouchAccel)
                Accel(1);
            else if (TouchBack)
                Accel(-1);
            else if (TouchBreaks)
            {
                if (AccelFwd)
                    StopAccel(1, Breaks);
                else if (AccelBwd)
                    StopAccel(-1, Breaks);
            }
            else
            {
                if (AccelFwd)
                    StopAccel(1, 0.1f);
                else if (AccelBwd)
                    StopAccel(-1, 0.1f);
            }
        }
    }

    // Functions to be called from Onscreen buttons for touch input.
    public void SetTouchAccel(bool TouchState)
    {
        TouchAccel = TouchState;
    }

    public void SetTouchBack(bool TouchState)
    {
        TouchBack = TouchState;
    }

    public void SetTouchBreaks(bool TouchState)
    {
        TouchBreaks = TouchState;
    }

    public void SetSteerLeft(bool TouchState)
    {
        SteerLeft = TouchState;
    }

    public void SetSteerRight(bool TouchState)
    {
        SteerRight = TouchState;
    }

    public void Accel(int Direction)
    {
        if (Direction == 1)
        {
            AccelFwd = true;
            if (Acceleration <= MaxSpeed)
            {
                Acceleration += 0.05f;
            }

            if (CarControlMode == controlMode.KeyBoard)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                    transform.Rotate(Vector3.forward * Steer);              //Steer left
                if (Input.GetKey(KeyCode.RightArrow))
                    transform.Rotate(Vector3.back * Steer);             //steer right
            }
            else if (CarControlMode == controlMode.Touch)
            {
                if (SteerLeft)
                    transform.Rotate(Vector3.forward * Steer);
                else if (SteerRight)
                    transform.Rotate(Vector3.back * Steer);
            }
        }
        else if (Direction == -1)
        {
            AccelBwd = true;
            if ((-1 * MaxSpeed) <= Acceleration)
            {
                Acceleration -= 0.05f;
            }

            if (CarControlMode == controlMode.KeyBoard)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                    transform.Rotate(Vector3.back * Steer);             //Steer left (while in reverse direction)
                if (Input.GetKey(KeyCode.RightArrow))
                    transform.Rotate(Vector3.forward * Steer);              //Steer left (while in reverse direction)
            }
            else if (CarControlMode == controlMode.Touch)
            {
                if (SteerLeft)
                    transform.Rotate(Vector3.forward * Steer);
                else if (SteerRight)
                    transform.Rotate(Vector3.back * Steer);
            }
        }

        if (Steer <= MaxSteer)
            Steer += 0.01f;

        if (CarControlMode == controlMode.Touch)
            transform.Translate(Vector2.up * Acceleration * Time.deltaTime);
        else if (CarControlMode == controlMode.KeyBoard)
            transform.Translate(Vector2.up * Acceleration * Time.deltaTime);
    }
    private System.Collections.IEnumerator CargarGameOver()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("GameOver");
    }

    // Método que se llama al colisionar con una persona y llama a fin de juego
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Accidente");
        Debug.Log(collision.gameObject);
        if (collision.gameObject.CompareTag("Persona"))
        {
            soundController.sonarBocina();
            //esperar 4 segundos
            StartCoroutine(CargarGameOver());
            //SceneManager.LoadScene("GameOver");
        }

    }

    public void StopAccel(int Direction, float BreakingFactor)
    {
        if (Direction == 1)
        {
            if (Acceleration >= 0.0f)
            {
                Acceleration -= BreakingFactor;

                if (CarControlMode == controlMode.KeyBoard)
                {
                    if (Input.GetKey(KeyCode.LeftArrow))
                        transform.Rotate(Vector3.forward * Steer);
                    if (Input.GetKey(KeyCode.RightArrow))
                        transform.Rotate(Vector3.back * Steer);
                }
                else if (CarControlMode == controlMode.Touch)
                {
                    if (SteerLeft)
                        transform.Rotate(Vector3.forward * Steer);
                    else if (SteerRight)
                        transform.Rotate(Vector3.back * Steer);
                }
            }
            else
                AccelFwd = false;
        }
        else if (Direction == -1)
        {
            if (Acceleration <= 0.0f)
            {
                Acceleration += BreakingFactor;

                if (CarControlMode == controlMode.KeyBoard)
                {
                    if (Input.GetKey(KeyCode.LeftArrow))
                        transform.Rotate(Vector3.back * Steer);
                    if (Input.GetKey(KeyCode.RightArrow))
                        transform.Rotate(Vector3.forward * Steer);
                }
                else if (CarControlMode == controlMode.Touch)
                {
                    if (SteerLeft)
                        transform.Rotate(Vector3.forward * Steer);
                    else if (SteerRight)
                        transform.Rotate(Vector3.back * Steer);
                }
            }
            else
                AccelBwd = false;
        }

        if (Steer >= 0.0f)
            Steer -= 0.01f;

        transform.Translate(Vector2.up * Acceleration * Time.deltaTime);
    }

    // Método que se llama al entrar en el césped: cambia la velocidad de la ambulancia y el sonido
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Borde"))
        {
            soundController.sonarCespedEnBucle();
            MaxSpeed = 2f;
            Acceleration = 1f;
        }
    }

    // Método que se llama al salir del césped: cambia la velocidad de la ambulancia y el sonido al inicial
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Borde"))
        {
            soundController.detenerCesped();
            MaxSpeed = velocidadUpdate;
        }
    }
}
