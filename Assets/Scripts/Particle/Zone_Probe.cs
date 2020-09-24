using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone_Probe : MonoBehaviour
{
	private int nb_collision = 0;
	private float tot_temp = 0.0f;

	private void OnTriggerEnter(Collider other)
	{
		nb_collision++;
		tot_temp += other.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
		Debug.Log(nb_collision + " " + tot_temp / nb_collision);
	}

	private void OnTriggerExit(Collider other)
	{
		
	}
}
