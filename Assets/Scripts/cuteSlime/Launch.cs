using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
	Rigidbody2D rb;
	Animator anim;
	SlimeStats slimeStats;

	bool inMidAir = false;

    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
        slimeStats = GetComponent<SlimeStats>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && slimeStats.canTriggerLaunch)
		{
			StartCoroutine(LaunchSequence());
		}
		else if (inMidAir && slimeStats.isTouchingFloor)
		{
			anim.SetBool("launch1", false);
			anim.SetBool("launch2", false);
			anim.SetBool("launch3", false);
			anim.SetBool("launch4", false);
			StartCoroutine(LandingSequence());
			inMidAir = false;
		}
    }
	
	IEnumerator LaunchSequence()
	{
		slimeStats.canTriggerLaunch = false;
		slimeStats.canTriggerTurn = false;
		slimeStats.canTriggerWalk = false;
		slimeStats.midLaunch = true;
		
		anim.SetBool("launch1", true);
		yield return new WaitForSeconds(SlimeStats.launchOneAnimationDuration);
		anim.SetBool("launch1", false);
		anim.SetBool("launch2", true);
		rb.velocity = new Vector2(16 * Mathf.Sign(transform.localScale.x),20);
		yield return new WaitForSeconds(SlimeStats.launchTwoAnimationDuration);
		inMidAir = true;
		yield return new WaitForSeconds(SlimeStats.launchTwoAnimationDuration);
		anim.SetBool("launch2", false);
		anim.SetBool("launch3", true);
		yield return new WaitForSeconds(SlimeStats.launchThreeAnimationDuration);
		anim.SetBool("launch3", false);
		anim.SetBool("launch4", true);
	}
	
	IEnumerator LandingSequence()
	{
		anim.SetBool("launch5", true);
		yield return new WaitForSeconds(SlimeStats.launchFiveAnimationDuration);
		anim.SetBool("launch5", false);
		slimeStats.canTriggerLaunch = true;
		slimeStats.canTriggerTurn = true;
		slimeStats.canTriggerWalk = true;
		slimeStats.midLaunch = false;
	}
}
