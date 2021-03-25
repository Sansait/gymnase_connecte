using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetToCollect : MonoBehaviour
{
	[SerializeField]
	private Portal_LevelManager myLevelManager;
	[SerializeField]
	private DeathParticles deathParticles;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Mass")
		{
			AudioManager.instance.Play("energy_void");
			deathParticles.PlayDeathParticles(this.transform.position);
			Destroy(gameObject);

			if(myLevelManager != null)
            {
				myLevelManager.NextStep();
            }
		}
	}


}
