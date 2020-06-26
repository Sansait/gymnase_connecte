using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePlayerBagNeg : MonoBehaviour
{
	[SerializeField] private GameObject circle;

	void Update()
	{
		Vector3 tmp = circle.transform.localScale;
		tmp.x -= .5f;
		tmp.z -= .5f;
		transform.localScale = tmp;
	}
}

