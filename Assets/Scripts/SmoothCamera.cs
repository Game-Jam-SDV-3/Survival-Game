using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform target; // Le joueur
    public float smoothSpeed = 0.1f; // Vitesse de lissage

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position; // Décalage initial
    }

    void LateUpdate()
    {
        // Calcul de la position désirée
        Vector3 desiredPosition = target.position + target.rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}
