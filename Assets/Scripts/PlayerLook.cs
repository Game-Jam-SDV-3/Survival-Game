using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Sensibilit� de la souris
    public Transform playerBody; // R�f�rence au corps du joueur

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Cache et verrouille le curseur
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -70f, 70f); // Emp�che de regarder trop haut/bas

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Rotation verticale
        playerBody.Rotate(Vector3.up * mouseX); 
        transform.Rotate(Vector3.up * mouseX); 

        Debug.DrawRay(transform.position, transform.forward * 10, Color.red); // Dessine un rayon devant le joueur

        // Mouvement lat�ral avec A et D
        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * 5f; // 5f = vitesse de d�placement
        playerBody.Translate(Vector3.right * moveX);
    }   
}
