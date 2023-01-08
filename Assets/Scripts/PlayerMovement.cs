using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigidBody;
    [SerializeField] float speed = 500f;
    [SerializeField] float moveLimiter = 0.71f;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        if(rigidBody == null)
        {
            Debug.LogError("rigidBody is undefined on PlayerMovement script");
        }
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        // limit diagonal movement because it is faster than cardinal movement
        if (horizontalMovement != 0 && verticalMovement != 0)
        {
            horizontalMovement *= moveLimiter;
            verticalMovement *= moveLimiter;
        }

        rigidBody.velocity = (transform.right * horizontalMovement * Time.fixedDeltaTime + transform.up * verticalMovement * Time.fixedDeltaTime) * speed;
    }
}
