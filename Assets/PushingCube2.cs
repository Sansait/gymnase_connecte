using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingCube2 : MonoBehaviour
{
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			this.GetComponent<Rigidbody>().AddForce(this.transform.right * 1000000f);
		}
		if (Input.GetKeyDown(KeyCode.X))
		{
			this.GetComponent<Rigidbody>().AddForce(-this.transform.right * 1000000f);
		}
	}
}
