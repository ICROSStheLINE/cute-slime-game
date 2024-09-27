using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayProjectile : MonoBehaviour
{
	Animator anim;
	SlimeStats slimeStats;
	
	[SerializeField] GameObject projectile;
	
	bool isSprayingDown = false;

    void Start()
    {
        anim = GetComponent<Animator>();
		slimeStats = GetComponent<SlimeStats>();
    }

    void Update()
    {
        if (Input.GetKeyDown("e") && slimeStats.canTriggerSprayUp && slimeStats.isTouchingFloor)
		{
			StartCoroutine(SprayUpSequence());
		}
		if (Input.GetKeyDown("e") && slimeStats.canTriggerSprayUp && !slimeStats.isTouchingFloor)
		{
			StartCoroutine(SprayDownSequence());
		}
		if (isSprayingDown && slimeStats.isTouchingFloor)
		{
			anim.SetBool("isSprayingUp", false);
			StopCoroutine("SprayDownSequence");
			slimeStats.canTriggerSprayUp = true;
			slimeStats.midSprayUp = false;
			isSprayingDown = false;
		}
    }

	IEnumerator SprayUpSequence()
	{
		slimeStats.canTriggerSprayUp = false;
		slimeStats.midSprayUp = true;
		slimeStats.canTriggerTurn = false;
		float offsetX = 0;
		float offsetZ = 0;
		if (Mathf.Sign(transform.localScale.x) == -1)
		{
			offsetX = 180;
			offsetZ = 180;
		}
		
		anim.SetBool("isSprayingUp", true);
		yield return new WaitForSeconds(SlimeStats.sprayUpAnimationDuration/5);
		Instantiate(projectile, transform.position, Quaternion.Euler(0 + offsetX,0,15 + offsetZ));
		yield return new WaitForSeconds(SlimeStats.sprayUpAnimationDuration/5);
		Instantiate(projectile, transform.position, Quaternion.Euler(0 + offsetX,0,30 + offsetZ));
		yield return new WaitForSeconds(SlimeStats.sprayUpAnimationDuration/5);
		Instantiate(projectile, transform.position, Quaternion.Euler(0 + offsetX,0,45 + offsetZ));
		yield return new WaitForSeconds(SlimeStats.sprayUpAnimationDuration/5);
		Instantiate(projectile, transform.position, Quaternion.Euler(0 + offsetX,0,60 + offsetZ));
		yield return new WaitForSeconds(SlimeStats.sprayUpAnimationDuration/5);
		anim.SetBool("isSprayingUp", false);
		
		slimeStats.canTriggerSprayUp = true;
		slimeStats.midSprayUp = false;
		slimeStats.canTriggerTurn = true;
	}

	IEnumerator SprayDownSequence()
	{
		slimeStats.canTriggerSprayUp = false;
		slimeStats.midSprayUp = true;
		isSprayingDown = true;
		slimeStats.canTriggerTurn = false;
		float offsetX = 0;
		float offsetZ = 0;
		if (Mathf.Sign(transform.localScale.x) == -1)
		{
			offsetX = 180;
			offsetZ = 180;
		}
		
		anim.SetBool("isSprayingUp", true);
		yield return new WaitForSeconds(SlimeStats.sprayUpAnimationDuration/5);
		Instantiate(projectile, transform.position, Quaternion.Euler(0 + offsetX,0,15 - 90  + offsetZ));
		Instantiate(projectile, transform.position, Quaternion.Euler(0 + offsetX,0,30 - 90  + offsetZ));
		Instantiate(projectile, transform.position, Quaternion.Euler(0 + offsetX,0,45 - 90  + offsetZ));
		Instantiate(projectile, transform.position, Quaternion.Euler(0 + offsetX,0,60 - 90  + offsetZ));
		yield return new WaitForSeconds(SlimeStats.sprayUpAnimationDuration/5);
		Instantiate(projectile, transform.position, Quaternion.Euler(0 + offsetX,0,68 - 90  + offsetZ));
		yield return new WaitForSeconds(SlimeStats.sprayUpAnimationDuration/5);
		Instantiate(projectile, transform.position, Quaternion.Euler(0 + offsetX,0,75 - 90  + offsetZ));
		yield return new WaitForSeconds(SlimeStats.sprayUpAnimationDuration/5);
		yield return new WaitForSeconds(SlimeStats.sprayUpAnimationDuration/5);
		anim.SetBool("isSprayingUp", false);
		
		slimeStats.canTriggerSprayUp = true;
		slimeStats.midSprayUp = false;
		isSprayingDown = false;
		slimeStats.canTriggerTurn = true;
	}
}
