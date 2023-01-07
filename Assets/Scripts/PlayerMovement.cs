using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigidBody;
    [SerializeField] float speed = 100f;

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

    void Update()
    {
    }

    private void HandleMovement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        //Vector2 direction = new Vector2(horizontalMovement, verticalMovement);
        //rigidBody.AddForce(direction * speed * Time.fixedDeltaTime);

        rigidBody.velocity = transform.right * horizontalMovement * speed * Time.fixedDeltaTime + transform.up * verticalMovement * speed * Time.fixedDeltaTime;
    }
}
