using UnityEngine;

public class DestruirFueraDeCamara : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector3 viewportPos = cam.WorldToViewportPoint(transform.position);

        // Si el enemigo sale por la parte inferior del viewport
        if (viewportPos.y < -1)
        {
            Destroy(gameObject);
        }
    }
}
