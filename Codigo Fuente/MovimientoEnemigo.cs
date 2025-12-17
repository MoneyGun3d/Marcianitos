using UnityEngine;


public class MovimientoEnemigo : MonoBehaviour
{

    const float FIN_DERECHA = 1f;
    const float FIN_IZQUIERDA = 0f;

    private Vector2 izquierda = new Vector2();
    private Vector2 derecha = new Vector2();


    [SerializeField]
    private float velocidad = 1f;
    [SerializeField]
    private float rangoIzquierda = -6f;
    [SerializeField]
    private float rangoDerecha = 6f;
    private float rango;

    private float progreso = 0f;
    bool direccionDerecha = true;


    void Start()
    {
        rango = Random.Range(rangoIzquierda, rangoDerecha);
        izquierda = transform.position;
        derecha = izquierda + new Vector2(rango, 0f);
    }

    // Update is called once per frame
    void Update()
    {

        if (direccionDerecha)
        {
            progreso += velocidad * Time.deltaTime;
        }
        else
        {
            progreso -= velocidad * Time.deltaTime;
        }

        if (progreso > FIN_DERECHA)
        {
            progreso = FIN_DERECHA;
        }
        if (progreso < FIN_IZQUIERDA)
        {
            progreso = FIN_IZQUIERDA;
        }

        Vector2 nuevaPos = Vector2.Lerp(izquierda, derecha, progreso);
        transform.position = nuevaPos;

        if (progreso >= FIN_DERECHA)
        {
            direccionDerecha = false;
        }
        else if (progreso <= FIN_IZQUIERDA)
        {
            direccionDerecha = true;
        }

    }
}
