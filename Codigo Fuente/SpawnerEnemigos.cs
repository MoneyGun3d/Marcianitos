using UnityEngine;

public class SpawnerEnemigos : MonoBehaviour
{
    [Header("Prefab del enemigo (2D)")]
    public GameObject enemigo;

    [Header("Tiempo entre spawns")]
    public float intervaloSpawn = 2f;

    [Header("Altura a la que aparecerán sobre la cámara")]
    public float alturaExtra = 2f;

    [Header("Rango horizontal del spawn")]
    public float rangoHorizontal = 3f;

    [Header("Probabilidad (%) de que salga un enemigo raro")]
    [Range(0, 100)]
    public int porcentajeEnemigoRaro = 20;

    [Header("Sprites de enemigos raros (3 sprites)")]
    public Sprite[] spritesRaros = new Sprite[3];

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= intervaloSpawn)
        {
            Spawn();
            timer = 0f;
        }
    }

    void Spawn()
    {
        // Posición base: encima de la cámara
        Vector3 camPos = transform.position;

        Vector3 posSpawn = new Vector3(
            camPos.x + Random.Range(-rangoHorizontal, rangoHorizontal),
            camPos.y + alturaExtra,
            0f
        );

        // Instanciar
        GameObject nuevoEnemigo = Instantiate(enemigo, posSpawn, Quaternion.identity);

        // Probabilidad de enemigo raro
        int randomNum = Random.Range(1, 100);

        if (randomNum < porcentajeEnemigoRaro)
        {
            HacerEnemigoRaro(nuevoEnemigo);
        }
    }

    void HacerEnemigoRaro(GameObject enemigo)
    {
        // Cambiar sprite
        SpriteRenderer sr = enemigo.GetComponent<SpriteRenderer>();

        if (sr != null && spritesRaros.Length >= 3)
        {
            sr.sprite = spritesRaros[Random.Range(0, spritesRaros.Length)];
        }

        // Cambiar tag
        enemigo.tag = "enemigoTier2";
    }
}
