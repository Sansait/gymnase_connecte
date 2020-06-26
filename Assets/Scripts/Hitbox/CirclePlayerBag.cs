using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePlayerBag : MonoBehaviour
{
	[SerializeField] private GameObject trackerPlayer;
	[SerializeField] private GameObject players;

	void Update()
	{
		Vector3 vec = trackerPlayer.transform.position - transform.position;
		Vector3 tmp = new Vector3(vec.magnitude * 2f, 0.1f, vec.magnitude * 2f);
		transform.localScale = tmp;
	}
}
