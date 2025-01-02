using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour {

	public int damageAmount = 2;
	public LayerMask enemyLayer;


	void Update()
	{

		Collider[] hits = Physics.OverlapSphere(transform.position, 0.7f, enemyLayer);

		if (hits.Length > 0)
		{
			if (hits[0].gameObject.tag == MyTags.ENEMY_TAG)
			{
				hits[0].gameObject.GetComponent<EnemyHealth>().ApplyDamage(damageAmount);
			}
		}
	}
}
