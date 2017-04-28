using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderController : MonoBehaviour {

    Vector3 defaultPos;

    void Awake ()
    {
        defaultPos = transform.position;
    }

	void OnTriggerEnter2D (Collider2D c)
    {
        if (c.tag == "BadBlock")
        {
            transform.position = defaultPos;
            transform.rotation = Quaternion.identity;
        }

        if (c.tag == "Star")
        {
            SceneManager.LoadScene("YouWin Scene");
        }
    }
}
