using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{

    public Transform nave;
    private int distanciaDelCentro = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nave != null)
        {
            transform.position = new Vector3 (0, nave.position.y + distanciaDelCentro, -10);

        }
    }
}
