using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CRI.ConnectedGymnasium
{
	public class Temperature_Display : MonoBehaviour
	{
		public Text scoreText;
		// Update is called once per frame
		void Update()
		{
			scoreText.text = Particle_Manager.Instance.averageSpeed.ToString();
		}
	}
}