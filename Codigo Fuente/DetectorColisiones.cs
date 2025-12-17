using UnityEngine;

public class DetectorColisiones : MonoBehaviour
{
    [SerializeField]
    private bool godMode = false;

    private HUDManager hud;

    void Start()
    {
        hud = FindFirstObjectByType<HUDManager>();
        if (hud == null)
        {
            Debug.LogError("HUDManager no encontrado en la escena");
            return;
        }

        // Le decimos al HUDManager cuál es el jugador
        hud.SetJugador(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitbox)
    {
        if (!godMode)
        {
            if (hitbox.CompareTag("enemigo"))
            {
                hud.PerderVida(1);
            }
            else if (hitbox.CompareTag("enemigoTier2"))
            {
                hud.PerderVida(2);
            }

            Collider2D col = hitbox.GetComponent<Collider2D>();
            if (col != null)
                col.enabled = false;
        }

        if (hitbox.CompareTag("meta"))
        {
            MovimientoNave mov = GetComponent<MovimientoNave>();
            mov.setVelocidadVertical(0f);
            mov.setVelocidadHorizontal(0f);

            SpawnerEnemigos spawner = Camera.main.GetComponent<SpawnerEnemigos>();
            if (spawner != null)
                spawner.enabled = false;

            foreach (var e in GameObject.FindGameObjectsWithTag("enemigo"))
                Destroy(e);

            foreach (var e in GameObject.FindGameObjectsWithTag("enemigoTier2"))
                Destroy(e);

            Disparar disp = GetComponent<Disparar>();
            if (disp != null)
                disp.enabled = false;

            Time.timeScale = 0f;
        }
    }
}
