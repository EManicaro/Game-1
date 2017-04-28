using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderController : MonoBehaviour {

    // the player's default position
    Vector3 defaultPos;

    // when the script is activated, get its components
    void Awake ()
    {
        defaultPos = transform.position;
    }

    // when the player hits an object with trigger, do something
    void OnTriggerEnter2D (Collider2D c)
    {
        // when the player hits a grey block, respawn
        if (c.tag == "BadBlock")
        {
            transform.position = defaultPos;
            transform.rotation = Quaternion.identity;
        }

        // when the player hits the gold star, load You Win scene
        if (c.tag == "Star")
        {
            SceneManager.LoadScene("YouWin Scene");
        }
    }
}
