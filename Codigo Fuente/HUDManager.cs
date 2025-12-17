using UnityEngine;
using UnityEngine.UIElements;

public class HUDManager : MonoBehaviour
{
    [Header("UI Document HUD")]
    public UIDocument hudDocument;

    private Label vidasLabel;
    private Label disparosLabel;

    private GameObject jugador;

    [Header("Stats")]
    public int vidas = 3;
    public int disparos = 10;

    public void SetJugador(GameObject j)
    {
        jugador = j;
    }

    void Awake()
    {
        if (hudDocument != null)
        {
            var root = hudDocument.rootVisualElement;

            vidasLabel = root.Q<Label>("textoVidas");
            disparosLabel = root.Q<Label>("textoDisparos");

            if (vidasLabel == null) Debug.LogError("No se encontró 'textoVidas'");
            if (disparosLabel == null) Debug.LogError("No se encontró 'textoDisparos'");
        }
        else
        {
            Debug.LogError("hudDocument no asignado en HUDManager");
        }

        ActualizarHUD();
    }

    public void PerderVida(int cantidad = 1)
    {
        vidas -= cantidad;
        if (vidas < 0) vidas = 0;

        if (vidas > 0)
            ActualizarHUD();

        if (vidas == 0)
        {
            Debug.Log("GAME OVER");

            if (jugador != null)
                Destroy(jugador);

            // Evitar errores UI Toolkit
            hudDocument.rootVisualElement.SetEnabled(false);

            Time.timeScale = 0f;
        }
    }


    public void Disparar(int cantidad = 1)
    {
        disparos -= cantidad;
        if (disparos < 0) disparos = 0;

        ActualizarHUD();
    }

    private void ActualizarHUD()
    {
        if (vidasLabel != null)
            vidasLabel.text = "Vidas: " + vidas;

        if (disparosLabel != null)
            disparosLabel.text = "Disparos: " + disparos;
    }
}
