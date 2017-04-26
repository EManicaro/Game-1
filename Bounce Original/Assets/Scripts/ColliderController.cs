using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
