using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatingHeart : MonoBehaviour
{

	[SerializeField] private int bpm = 80;
	private float _timeKeeper = 0f;
	private bool beat = false;

	// Update is called once per frame
	void Update()
	{
		_timeKeeper += Time.deltaTime;
		float timeBetweenBeats = 60f / bpm;
		Vector3 scale = transform.localScale;
		if (_timeKeeper >= timeBetweenBeats)
		{
			_timeKeeper -= timeBetweenBeats;
			beat = true;
		}
		if (beat == true && scale.x != 11f)
		{
			scale.x += .5f;
			scale.z += .5f;
			transform.localScale = scale;
			if (scale.x == 11f)
				beat = false;
		}
		else if (beat == false && scale.x != 10f)
		{
			scale.x -= .5f;
			scale.z -= .5f;
			transform.localScale = scale;
		}
	}
}
