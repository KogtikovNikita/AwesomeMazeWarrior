using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public int health = 100;
	private PlayerScript playerScript;

	private Animator anim;

	void Awake () {
		playerScript = GetComponent<PlayerScript>();
		anim = GetComponent<Animator>();
	}
	
	public void ApplyDamage(int damageAmount)
    {
		health -= damageAmount;

		if (health < 0)
			health = 0;
	
		// DISPLAY THE HEALTH VALUE

		if (health == 0)
        {
			playerScript.enabled = false;
			anim.Play(MyTags.DEAD_ANIMATION);

			//CALL GAME OVER
        }

    }

	


}
