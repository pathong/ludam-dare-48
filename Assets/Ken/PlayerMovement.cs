using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private static bool PlayerExist;

    public float speed;

    private void Update()
    {
        HandleMovement();
    }
    private void HandleMovement()
    {
        float moveX = 0f;
        float moveY = 0f;
        Vector3 flip = transform.localScale;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 1.5f;
        }
        else
        {
            speed = 3f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            moveY = +1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
        }

        Vector3 moveDir = new Vector3(moveX, moveY).normalized;
        transform.localScale = flip;
        transform.position += moveDir * speed * Time.deltaTime;
    }
}
