using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FedoraFlamingoAttackSlash : MonoBehaviour
{
	PolygonCollider2D polygonCollider2D;
	
	static readonly float animationDurationSpeedMultiplier = 1f;
	static readonly float animationDuration = 0.667f / animationDurationSpeedMultiplier;
	static readonly float animationFrames = 8;
	
	Vector2[] path1 = {new Vector2(2.5f,-2.4f), new Vector2(2.4f,-2.7f), new Vector2(2.93f,-3.1f), new Vector2(3.2f,-3.1f)};
	Vector2[] path2 = {new Vector2(1.6f,-1.4f), new Vector2(1.44f,-1.59f), new Vector2(2.93f,-3.1f), new Vector2(3.2f,-3.1f)};
	Vector2[] path3 = {new Vector2(0.66f,-0.53f), new Vector2(0.6f,-0.77f), new Vector2(2.93f,-3.1f), new Vector2(3.2f,-3.1f)};
	Vector2[] path4 = {new Vector2(-0.58f,0.74f), new Vector2(-0.76f,0.63f), new Vector2(2.93f,-3.1f), new Vector2(3.2f,-3.1f)};
	Vector2[] path5 = {new Vector2(-2.25f,2.39f), new Vector2(-2.35f,2.22f), new Vector2(2.43f,-2.53f), new Vector2(2.55f,-2.42f)};
	Vector2[] path6 = {new Vector2(-2.73f,2.85f), new Vector2(-2.86f,2.75f), new Vector2(0.84f,-0.97f), new Vector2(0.98f,-0.8f)};
	Vector2[] path7 = {new Vector2(-2.94f,3.05f), new Vector2(-3.01f,2.9f), new Vector2(-0.5f,0.38f), new Vector2(-0.38f,0.45f)};
	Vector2[] path8 = {new Vector2(-2.94f,3.05f), new Vector2(-3.01f,2.9f), new Vector2(-2.05f,1.92f), new Vector2(-1.95f,2.05f)};


    void Start()
    {
		polygonCollider2D = GetComponent<PolygonCollider2D>();
		StartCoroutine(UpdateCollider());
    }

    IEnumerator UpdateCollider()
    {
		polygonCollider2D.SetPath(0, path1);
        yield return new WaitForSeconds((1 / animationFrames) * animationDuration);
		polygonCollider2D.SetPath(0, path2);
		yield return new WaitForSeconds((1 / animationFrames) * animationDuration);
		polygonCollider2D.SetPath(0, path3);
		yield return new WaitForSeconds((1 / animationFrames) * animationDuration);
		polygonCollider2D.SetPath(0, path4);
		yield return new WaitForSeconds((1 / animationFrames) * animationDuration);
		polygonCollider2D.SetPath(0, path5);
		yield return new WaitForSeconds((1 / animationFrames) * animationDuration);
		polygonCollider2D.SetPath(0, path6);
		yield return new WaitForSeconds((1 / animationFrames) * animationDuration);
		polygonCollider2D.SetPath(0, path7);
		yield return new WaitForSeconds((1 / animationFrames) * animationDuration);
		polygonCollider2D.SetPath(0, path8);
		yield return new WaitForSeconds((1 / animationFrames) * animationDuration);
		Destroy(gameObject);
    }
}
