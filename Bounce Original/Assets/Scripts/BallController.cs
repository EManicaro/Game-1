using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour {

    // the character's speed
    float speed = 5f;

    // the character's jump force
    float jumpForce = 250f;

    // this is the character's physiscs component
    Rigidbody2D playerRB;

    // this is the character's sprite renderer
    SpriteRenderer spriteRenderer;

    // player lives
    public int playerLives = 2;

    // the canvas text box
    public Text lifeText;

    // the player's default position
    Vector3 defaultPos;

    // when the script is activated, get its components
    void Awake ()
    {
        playerRB = GetComponent <Rigidbody2D> ();
        spriteRenderer = GetComponent<SpriteRenderer>();

        defaultPos = transform.position;
    }

    // since we're using physics, use the FixedUpdate method
    void FixedUpdate ()
    {
        // this tackles the left and right arrow keys
        float h = Input.GetAxisRaw("Horizontal");

        // jump to the Move method
        Move(h);

        // make the character jump!
        if (Input.GetButtonDown ("Jump"))
        {
            playerRB.AddForce(Vector2.up * jumpForce);
        }
    }

    // when the player disappears, resst him
    void OnBecameInvisible()
    {
        // when lives are greater then 0 minus 1, less then 0 gameover
        if (transform.position.y < 0)
        {
            //if the lives are greater than 0, decrease by 1
            if (playerLives > 1)
            {
                playerLives--;

                //adjust the life on canvas
                lifeText.text = "Lives: " + playerLives;

                // show us the score in the console (Ctrl + Shift + C in Unity
                Debug.Log(playerLives);
            }

            //else gameover
            else
            {
                SceneManager.LoadScene("GameOver Scene");
            }
        }
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

    // collide with the star and destory them
    void OnTriggerEnter2D(Collider2D c)
    {

        if (c.tag == "Star")
        {
            Destroy(c.gameObject);
        }

    }
}
