using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
	[SerializeField] GameObject objectToFollow;
	[SerializeField] Vector2 offset;
	[SerializeField] float speed = 0;

    void Start()
    {
        
    }

    void Update()
    {
		if (objectToFollow)
		{
			transform.position = Vector3.MoveTowards(transform.position, objectToFollow.transform.position + new Vector3(offset.x, offset.y, 0), speed * Time.deltaTime);
		}
		else
		{
			Destroy(gameObject);
		}
    }
}
