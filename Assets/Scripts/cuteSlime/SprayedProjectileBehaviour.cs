using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayedProjectileBehaviour : MonoBehaviour
{
	Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(transform.right.x * 25, transform.right.y * 25);
		Destroy(gameObject, 0.5f);
    }
}
