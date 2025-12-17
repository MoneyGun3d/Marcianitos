using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class MantenerEnCamara : MonoBehaviour
{

    private CapsuleCollider2D colision;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        colision = GetComponent<CapsuleCollider2D>();    
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float altoCamara = Camera.main.orthographicSize;
        float anchoCamara = altoCamara * Camera.main.aspect;

        float anchoCapsula;

        if (colision.direction == CapsuleDirection2D.Vertical)
        {
            anchoCapsula = (colision.size.x * transform.localScale.x) / 2f;
        }
        else
        {
            anchoCapsula = (colision.size.y * transform.localScale.y) / 2f;
        }


        Vector3 posicion = transform.position;
        Vector3 posicionCamara = Camera.main.transform.position;

        posicion.x = Mathf.Clamp(posicion.x,
                                 posicionCamara.x - anchoCamara + anchoCapsula,
                                 posicionCamara.x + anchoCamara - anchoCapsula);

        transform.position = posicion;
    }
}
