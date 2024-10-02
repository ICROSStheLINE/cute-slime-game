using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FedoraFlamingoBehaviour : MonoBehaviour
{
	Rigidbody2D rb;
	Animator anim;

	static readonly float idleAnimationDurationSpeedMultiplier = 0.25f;
	static readonly float idleAnimationDuration = 0.167f / idleAnimationDurationSpeedMultiplier;

	static readonly float walkAnimationDurationSpeedMultiplier = 0.5f;
	static readonly float walkAnimationDuration = 0.167f / walkAnimationDurationSpeedMultiplier;

	static readonly float deathAnimationDurationSpeedMultiplier = 1f;
	static readonly float deathAnimationDuration = 0.667f / deathAnimationDurationSpeedMultiplier;

	static readonly float attackAnimationDurationSpeedMultiplier = 0.5f;
	static readonly float attackAnimationDuration = 0.750f / attackAnimationDurationSpeedMultiplier;
	static readonly float attackAnimationFrames = 9;
	static readonly float attackProjectileSpawn = (7 / attackAnimationFrames) * attackAnimationDuration;


	[SerializeField] GameObject attackSlashGlint;
	[SerializeField] GameObject attackSlash;
    [SerializeField] float pacingDistance = 45f;
	bool isPacing = true;
	[HideInInspector] public bool isAttacking = false;
	float movementSpeed = 7;
	Vector2 startingPoint;
	Vector2 turningPoint;
	bool isDying = false;

    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		startingPoint = rb.position;
		turningPoint = startingPoint + new Vector2(pacingDistance,0);
    }

	void Update()
	{
		if (isDying)
			return;
		if (isPacing)
		{
			anim.SetBool("isWalking", true);
			rb.position += new Vector2(movementSpeed * Time.deltaTime, 0);
			if (rb.position.x >= turningPoint.x && Mathf.Sign(startingPoint.x - turningPoint.x) == -1 || rb.position.x <= turningPoint.x && Mathf.Sign(startingPoint.x - turningPoint.x) == 1)
			{
				isPacing = false;
				StartCoroutine("IdleThenPace");
			}
		}
	}

	IEnumerator IdleThenPace()
	{
		anim.SetBool("isWalking", false);
		yield return new WaitForSeconds(2);
		Turn();
		isPacing = true;
	}

	void Turn()
	{
		movementSpeed *= -1;
		Vector2 dogshit = turningPoint;
		turningPoint = startingPoint;
		startingPoint = dogshit;
		transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
	}

	public IEnumerator Attack()
	{
		isAttacking = true;
		isPacing = false;
		StopCoroutine("IdleThenPace");
		anim.SetBool("isWalking", false);
		anim.SetBool("isAttacking", true);
		yield return new WaitForSeconds(attackProjectileSpawn);
		GameObject slashGlint = Instantiate(attackSlashGlint, gameObject.transform.position + new Vector3(0.5f*Mathf.Sign(transform.localScale.x) * -1,-0.5f,0), gameObject.transform.rotation);
		slashGlint.transform.localScale = transform.localScale;
		GameObject slash = Instantiate(attackSlash, gameObject.transform.position + new Vector3(4.2f*Mathf.Sign(transform.localScale.x) * -1,3f,0), gameObject.transform.rotation);
		slash.transform.localScale = transform.localScale;
		yield return new WaitForSeconds((2 / attackAnimationFrames) * attackAnimationDuration);
		anim.SetBool("isAttacking", false);
		isPacing = true;
		isAttacking = false;
	}
	
	void Die()
	{
		StopAllCoroutines();
		isDying = true;
		anim.SetBool("isDying", true);
		Destroy(gameObject, deathAnimationDuration);
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Slime Spray Projectile")
		{
			Die();
		}
	}

}
