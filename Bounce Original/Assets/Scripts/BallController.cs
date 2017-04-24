using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    float speed = 5f;

    float jumpForce = 300f;

    Rigidbody2D playerRB;

    SpriteRenderer spriteRenderer;

    Vector3 defaultPos;

    void Awake ()
    {
        playerRB = GetComponent <Rigidbody2D> ();
        spriteRenderer = GetComponent<SpriteRenderer>();

        defaultPos = transform.position;
    }

    void FixedUpdate ()
    {
        float h = Input.GetAxisRaw("Horizontal");

        Move(h);

        if (Input.GetButtonDown ("Jump"))
        {
            playerRB.AddForce(Vector2.up * jumpForce);
        }
    }

    void OnBecameInvisible()
    {
        transform.position = defaultPos;
        transform.rotation = Quaternion.identity;
    }

    void Move(float h)
    {

        //refer to the current physics movement
        Vector2 movement = playerRB.velocity;
        movement.x = h * speed;

        // make the charcater move
        playerRB.velocity = movement;

        // check that the player is looking in the direction he's moving
        if ((h < 0f && !spriteRenderer.flipX) || (h > 0f && spriteRenderer.flipX))
        {

            spriteRenderer.flipX = !spriteRenderer.flipX;

        }

     }
}
