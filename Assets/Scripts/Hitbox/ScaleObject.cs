using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject : MonoBehaviour
{
	[SerializeField] private GameObject players;

	// Update is called once per frame
	void Update()
	{
		Vector3 tmp = new Vector3(1 / players.transform.localScale.x, players.transform.localScale.y, 1 / players.transform.localScale.x);
		this.transform.localScale = tmp;
	}
}
