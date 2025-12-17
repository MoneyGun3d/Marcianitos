using UnityEngine;
using UnityEngine.InputSystem;

public class Disparar : MonoBehaviour
{
    [Header("Configuración")]
    public bool balasInfinitas = false;   // ← NUEVO

    [Header("Referencias")]
    public Camera camara;
    public HUDManager hudManager;
    public GameObject naveNormalPrefab;
    public RayoDisparado rayo;
    public GameObject particulasImpacto;

    [Header("Distancia de Spawn")]
    public float distanciaSpawn = 1.5f;

    void Start()
    {
        if (camara == null)
            camara = Camera.main;

        if (hudManager == null)
            Debug.LogError("HUDManager no asignado en Disparar");

        if (rayo == null)
            Debug.LogError("RayoDisparado no asignado en Disparar");

        if (particulasImpacto == null)
            Debug.LogWarning("No se asignaron partículas de impacto en Disparar.");
    }

    void Update()
    {
        if (Mouse.current == null)
            return;

        // Botón izquierdo → disparar
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            IntentarDisparar();
        }

        // Botón derecho → ya NO hace nada
    }

    void IntentarDisparar()
    {
        // Revisar si hay balas, excepto si son infinitas
        if (!balasInfinitas && hudManager.disparos <= 0)
        {
            return;
        }

        // Obtener posición del clic
        Vector2 mousePosPantalla = Mouse.current.position.ReadValue();
        Vector3 mousePosMundo = camara.ScreenToWorldPoint(mousePosPantalla);
        Vector2 click2D = new Vector2(mousePosMundo.x, mousePosMundo.y);

        // Raycast
        RaycastHit2D hit = Physics2D.Raycast(click2D, Vector2.zero);

        if (hit.collider != null)
        {
            GameObject obj = hit.collider.gameObject;

            if (obj.CompareTag("enemigo") || obj.CompareTag("enemigoTier2"))
            {
                // ORIGEN del rayo (ligeramente hacia arriba)
                Vector3 origen = transform.position + transform.up * 0.5f;
                Vector3 destino = obj.transform.position;

                rayo.LanzarRayo(origen, destino);

                // PARTÍCULAS DE IMPACTO
                if (particulasImpacto != null)
                {
                    GameObject p = Instantiate(particulasImpacto, destino, Quaternion.identity);
                    Destroy(p, 2f);
                }

                Destroy(obj);

                // Descontar balas solo si NO son infinitas
                if (!balasInfinitas)
                    hudManager.Disparar(1);

                return;
            }
        }

        // Si no dio a un enemigo → spawn nave normal
        Vector3 spawnPos = transform.position + transform.up * distanciaSpawn;
        Instantiate(naveNormalPrefab, spawnPos, Quaternion.identity);

        if (!balasInfinitas)
            hudManager.Disparar(1);
    }
}
