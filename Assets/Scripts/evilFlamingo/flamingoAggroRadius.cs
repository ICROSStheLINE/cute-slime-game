using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flamingoAggroRadius : MonoBehaviour
{
	GameObject daddyFlamingo;
	flamingoBehaviour daddyFlamingoBehaviour;
	FedoraFlamingoBehaviour fedoraFlamingoBehaviour;
	bool fedora = false;

    void Start()
    {
        daddyFlamingo = gameObject.transform.parent.gameObject;
		if (daddyFlamingo.GetComponent<flamingoBehaviour>())
		{
			daddyFlamingoBehaviour = daddyFlamingo.GetComponent<flamingoBehaviour>();
		}
		else if (daddyFlamingo.GetComponent<FedoraFlamingoBehaviour>())
		{
			fedoraFlamingoBehaviour = daddyFlamingo.GetComponent<FedoraFlamingoBehaviour>();
			fedora = true;
		}
    }

    void Update()
    {
        
    }
	
	void OnTriggerStay2D(Collider2D collision)
	{
		if (fedora)
		{
			if ((collision.gameObject.tag == "Player") && (fedoraFlamingoBehaviour.isAttacking == false))
			{
				fedoraFlamingoBehaviour.StartCoroutine("Attack");
			}
		}
		else
		{
			if ((collision.gameObject.tag == "Player") && (daddyFlamingoBehaviour.isAttacking == false))
			{
				daddyFlamingoBehaviour.StartCoroutine("Attack");
			}
		}
	}
}
