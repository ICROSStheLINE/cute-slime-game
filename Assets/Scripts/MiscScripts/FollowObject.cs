using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
	[SerializeField] GameObject objectToFollow;
	[SerializeField] Vector3 offset;
	[SerializeField] float speed = 0;
	[SerializeField] bool destroyIfFollowedObject = true;

    void Start()
    {
        
    }

    void Update()
    {
		if (objectToFollow)
		{
			transform.position = Vector3.MoveTowards(transform.position, objectToFollow.transform.position + new Vector3(offset.x, offset.y, offset.z), speed * Time.deltaTime);
		}
		else if (destroyIfFollowedObject)
		{
			Destroy(gameObject);
		}
    }
}
