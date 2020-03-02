using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CRI.ConnectedGymnasium
{
	public class Calibration : MonoBehaviour
	{
		[SerializeField] private GameObject CenterCalibration;
		[SerializeField] private GameObject UpperCalibration;
		private GameObject tracker1;
		private GameObject tracker2;
		private GameObject players;

		private void Awake()
		{
			players = GameObject.Find("Players");
			tracker1 = GameObject.Find("Player1");
			tracker2 = GameObject.Find("Player2");
		}

		public void Calibrate()
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
