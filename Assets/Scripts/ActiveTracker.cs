using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTracker : MonoBehaviour
{
	public bool active = false;
	public bool toActivate = false;
	private Vector3 lastPos = Vector3.zero;
	private int i = 0;

	private void FixedUpdate()
	{
		if (active == false)
		{
			if (i < 100)
				i++;
			else if (i == 100)
			{
				lastPos = this.transform.position;
				i++;
			}
			else if (lastPos != this.transform.position)
			{
				toActivate = true;
			}
		}
	}
}
