using UnityEngine;

public class Player : Entity
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UsePower();
        }

        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.Z))
        {
            moveDirection += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += Vector3.back;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            moveDirection += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += Vector3.right;
        }

        if (moveDirection != Vector3.zero)
        {
            Move(moveDirection.normalized);
        }
    }
}
