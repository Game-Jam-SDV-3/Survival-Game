using UnityEngine;

public class Camera : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 300;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotationY = 0f;
        Vector3 translation = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            translation.z = speed * Time.deltaTime;
            Debug.Log("W");
        }
        if (Input.GetKey(KeyCode.S))
        {
            translation.z = -speed * Time.deltaTime;
            Debug.Log("S");
        }
        if (Input.GetKey(KeyCode.A))
        {
            translation.x = -speed * Time.deltaTime;
            Debug.Log("A");
        }
        if (Input.GetKey(KeyCode.D))
        {
            translation.x = speed * Time.deltaTime;
            Debug.Log("D");
        }

        if (Input.GetKey(KeyCode.Space))
        {
            translation.y = speed * Time.deltaTime;
            Debug.Log("Space");
        }
        if (Input.GetKey(KeyCode.X))
        {
            translation.y = -speed * Time.deltaTime;
            Debug.Log("X");
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, (rotationY - rotationSpeed) * Time.deltaTime, 0);
            Debug.Log("Q");
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, (rotationY + rotationSpeed) * Time.deltaTime, 0);
            Debug.Log("E");
        }

        if (translation != Vector3.zero)
        {
            transform.Translate(translation);
        }

    }
}
