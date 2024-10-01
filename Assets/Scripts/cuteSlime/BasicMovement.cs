using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
	Rigidbody2D rb;
	Animator anim;
	SlimeStats slimeStats;
	
	float force = 0;
	float movementSpeed = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		slimeStats = GetComponent<SlimeStats>();
    }


    void Update()
    {
		CheckForce();
		CheckApplyAnimation();
		CheckApplySideSwitch();
		ApplyForce();
    }
	
	
	void CheckForce()
	{
		if (slimeStats.canTriggerWalk == false)
			return;
		
        if (Input.GetKey("d"))
		{
			force += movementSpeed;
		}
		if (Input.GetKey("a"))
		{
			force -= movementSpeed;
		}
	}
	
	void ApplyForce()
	{
		rb.position += new Vector2(force * Time.deltaTime, 0);
		force = 0;
	}
	
	void CheckApplySideSwitch()
	{
		if (slimeStats.canTriggerTurn == false)
			return;
		
		if (Input.GetKey("d"))
		{
			transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
		}
		else if (Input.GetKey("a"))
		{
			transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
		}
	}
	
	void CheckApplyAnimation()
	{
		if (force != 0)
		{
			anim.SetBool("isWalking", true);
		}
		else
		{
			anim.SetBool("isWalking", false);
		}
	}
}
