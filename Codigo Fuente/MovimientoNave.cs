using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoNave : MonoBehaviour
{

    [SerializeField]
    private float velocidadHorizontal = 15f;
    [SerializeField]
    private float velocidadVertical = 6f;
    Vector2 direccion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.position += (Vector3)(Vector2.up * velocidadVertical * Time.deltaTime);

        direccion = Vector2.zero;

        //Izquierda
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            direccion += Vector2.left;
        }

        //Derecha
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            direccion += Vector2.right;
        }

        transform.position += (Vector3)(direccion * velocidadHorizontal * Time.deltaTime);

    }

    public void setVelocidadVertical(float velocidad)
    {
        this.velocidadVertical = velocidad;
    }

    public void setVelocidadHorizontal(float velocidad)
    {
        this.velocidadHorizontal = velocidad;
    }
}
