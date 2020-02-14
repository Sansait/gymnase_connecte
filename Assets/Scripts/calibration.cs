using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace calibration
{
	public class calibration : MonoBehaviour
	{
		[SerializeField] private GameObject tracker1;
		[SerializeField] private GameObject tracker2;
		[SerializeField] private GameObject CenterCalibration;
		[SerializeField] private GameObject UpperCalibration;
		[SerializeField] private GameObject players;

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
				Calibrate();
		}

		void Calibrate()
		{
			Vector3 rotation = Vector3.zero;
			rotation.y = -Vector3.Angle((tracker2.transform.position - tracker1.transform.position).normalized, (UpperCalibration.transform.position - CenterCalibration.transform.position).normalized);
			players.transform.rotation = Quaternion.Euler(rotation);
			Debug.Log(rotation);

			Vector3 scale = Vector3.zero;
			scale.x = (UpperCalibration.transform.position - CenterCalibration.transform.position).magnitude / (tracker2.transform.position - tracker1.transform.position).magnitude;
			scale.y = 1;
			scale.z = scale.x;
			Debug.Log("scale " + scale);
			players.transform.localScale = scale;

			players.transform.position += CenterCalibration.transform.position - tracker1.transform.position;
			Debug.Log(players.transform.position);

			this.gameObject.SetActive(false);
		}
	}
}
