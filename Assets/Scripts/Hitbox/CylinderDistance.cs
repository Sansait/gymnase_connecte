using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderDistance : MonoBehaviour
{
	[SerializeField] GameObject tracker1;
	[SerializeField] GameObject tracker2;

	// Update is called once per frame
	void Update()
	{
		Vector3 target = tracker1.transform.position - tracker2.transform.position;
		Vector3 pos = tracker2.transform.position + target.normalized * (target.magnitude / 2);
		transform.position = pos;
		Vector3 scale = transform.localScale;
		scale.z = target.magnitude / 2;
		transform.localScale = scale;
		Quaternion rotation = Quaternion.LookRotation(target);
		transform.rotation = rotation;
	}
}
