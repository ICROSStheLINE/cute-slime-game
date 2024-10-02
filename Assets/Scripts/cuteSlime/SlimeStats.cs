using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStats : MonoBehaviour
{
	Animator anim;
	
	public bool isTouchingFloor = false;
	
	public bool canTriggerWalk = true;
	public bool canTriggerTurn = true;
	public bool canTriggerLaunch = true;
	public bool canTriggerSprayUp = true;
	
	public bool midLaunch = false;
	public bool midSprayUp = false;
	
	
	// NOTE:
	// Since these animation variables are STATIC, when accessing them from other classes you must access it from the CLASS, not the INSTANCE
	// In other words, type "SlimeStats.idleAnimationDuration" instead of "slimeStats.idleAnimationDuration".
	// Pay attention to the fact that the "S" in "SlimeStats." is capitalized. That means you're accessing from the class.
	public static readonly float idleAnimationDurationSpeedMultiplier = 0.5f;
	public static readonly float idleAnimationDuration = 0.5f / idleAnimationDurationSpeedMultiplier;

	public static readonly float walkAnimationDurationSpeedMultiplier = 0.5f;
	public static readonly float walkAnimationDuration = 0.5f / walkAnimationDurationSpeedMultiplier;

	public static readonly float launchOneAnimationDurationSpeedMultiplier = 1;
	public static readonly float launchOneAnimationDuration = 0.333f / launchOneAnimationDurationSpeedMultiplier;
	public static readonly float launchOneAnimationFrames = 4;
	
	public static readonly float launchTwoAnimationDurationSpeedMultiplier = 1;
	public static readonly float launchTwoAnimationDuration = 0.250f / launchTwoAnimationDurationSpeedMultiplier;
	public static readonly float launchTwoAnimationFrames = 3;
	
	public static readonly float launchThreeAnimationDurationSpeedMultiplier = 1;
	public static readonly float launchThreeAnimationDuration = 0.417f / launchThreeAnimationDurationSpeedMultiplier;
	public static readonly float launchThreeAnimationFrames = 5;
	
	public static readonly float launchFourAnimationDurationSpeedMultiplier = 1;
	public static readonly float launchFourAnimationDuration = 0.5f / launchFourAnimationDurationSpeedMultiplier;
	public static readonly float launchFourAnimationFrames = 6;
	
	public static readonly float launchFiveAnimationDurationSpeedMultiplier = 1;
	public static readonly float launchFiveAnimationDuration = 0.75f / launchFiveAnimationDurationSpeedMultiplier;
	public static readonly float launchFiveAnimationFrames = 9;
	
	public static readonly float sprayUpAnimationDurationSpeedMultiplier = 1.25f;
	public static readonly float sprayUpAnimationDuration = 0.75f / sprayUpAnimationDurationSpeedMultiplier;
	public static readonly float sprayUpAnimationFrames = 9;
	
	public static readonly float dieAnimationDurationSpeedMultiplier = 0.5f;
	public static readonly float dieAnimationDuration = 0.5f / dieAnimationDurationSpeedMultiplier;
	public static readonly float dieAnimationFrames = 6;
	
	void Start()
	{
		anim = GetComponent<Animator>();
	}
	
	public void Die()
	{
		canTriggerLaunch = false;
		canTriggerSprayUp = false;
		canTriggerTurn = false;
		canTriggerWalk = false;
		anim.SetBool("isSprayingUp", false);
		anim.SetBool("isDying", true);
		Destroy(gameObject, dieAnimationDuration);
	}
	
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Floor")
		{
			isTouchingFloor = true;
		}
	}
	
	void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Floor")
		{
			isTouchingFloor = false;
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Death Zone")
		{
			Die();
		}
	}
	
	
	
}
