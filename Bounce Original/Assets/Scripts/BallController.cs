using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    float speed = 5f;

    float jumpForce = 500f;

    Rigidbody2D playerRB;

    void Awake ()
    {
        playerRB = GetComponent <Rigidbody2D> ();
    }

    void FixedUpdate ()
    {
        float h = Input.GetAxisRaw("Horizontal");


        if (Input.GetButtonDown ("Jump"))
        {
            playerRB.AddForce(Vector2.up * jumpForce);
        }
    }
 }
