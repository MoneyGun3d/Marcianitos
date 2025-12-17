using UnityEngine;

public class RayoDisparado : MonoBehaviour
{
    private LineRenderer lr;
    
    private float tiempoVida = 0.15f;
    private float tiempoActual = 0f;

    [SerializeField]
    private float grosorInicial = 0.35f;
    private float grosorFinal = 0f;

    private bool activo = false;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        gameObject.SetActive(false);
    }

    public void LanzarRayo(Vector3 origen, Vector3 destino)
    {
        gameObject.SetActive(true);

        lr.SetPosition(0, origen);
        lr.SetPosition(1, destino);

        lr.startWidth = grosorInicial;
        lr.endWidth = grosorInicial * 0.5f;

        tiempoActual = 0f;
        activo = true;
    }

    void Update()
    {
        if (!activo) return;

        tiempoActual += Time.deltaTime;
        float factor = 1f - (tiempoActual / tiempoVida);

        lr.startWidth = Mathf.Lerp(grosorFinal, grosorInicial, factor);
        lr.endWidth = Mathf.Lerp(grosorFinal, grosorInicial * 0.5f, factor);

        if (tiempoActual >= tiempoVida)
        {
            activo = false;
            gameObject.SetActive(false);
        }
    }
}
