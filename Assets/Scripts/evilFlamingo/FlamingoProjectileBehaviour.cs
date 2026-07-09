using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamingoProjectileBehaviour : MonoBehaviour
{
	float movementSpeed = 5f;

    void Start()
    {
        movementSpeed = movementSpeed * Mathf.Sign(transform.localScale.x) * -1;
		Destroy(gameObject, 2f);
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(movementSpeed * Time.fixedDeltaTime,0,0);
    }

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			Destroy(gameObject, 0.05f);
		}
	}
}
