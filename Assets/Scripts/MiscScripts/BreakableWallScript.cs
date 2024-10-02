using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWallScript : MonoBehaviour
{
	

    void Start()
    {
        
    }


    void Update()
    {
        
    }
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Slime Spray Projectile" && Mathf.Sign(transform.localScale.z) != -1)
		{
			foreach (Transform child in transform.parent)
			{
				child.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
				child.localScale = new Vector3(child.localScale.x, child.localScale.y, -1);
				StartCoroutine(VanishBlock(child));
			}
		}
	}
	
	IEnumerator VanishBlock(Transform block)
	{
		SpriteRenderer spriteRenderer = block.GetComponent<SpriteRenderer>();
		yield return new WaitForSeconds(1f);
		for (int i = 0; i < 3; i++)
		{
			spriteRenderer.color = new Color(1f,1f,1f,0f);
			yield return new WaitForSeconds(0.2f);
			spriteRenderer.color = new Color(1f,1f,1f,1f);
			yield return new WaitForSeconds(0.2f);
		}
		Destroy(block.gameObject);
	}
}
