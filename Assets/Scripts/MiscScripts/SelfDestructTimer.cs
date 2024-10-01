using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructTimer : MonoBehaviour
{
	[SerializeField] float deathTimer = 1f;
	
    void Start()
    {
        Destroy(gameObject, deathTimer);
    }
}
