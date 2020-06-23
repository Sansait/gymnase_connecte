using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePlayerBagNeg : MonoBehaviour
{
	[SerializeField] private GameObject circle;

	void Update()
	{
		Vector3 tmp = circle.transform.localScale;
		tmp.x -= 1;
		tmp.z -= 1;
		transform.localScale = tmp;
	}
}

