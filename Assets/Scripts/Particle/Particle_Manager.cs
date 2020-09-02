using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CRI.ConnectedGymnasium
{
	public class Particle_Manager : MonoBehaviour
	{
		private static Particle_Manager _instance;
		public static Particle_Manager Instance
		{
			get
			{
				if (_instance == null)
					Debug.LogError("Particle Manager is NULL.");
				return (_instance);
			}
		}

		[SerializeField]
		private GameObject particle;
		[SerializeField]
		private int nb_particle = 1;
		[SerializeField]
		public int init_temp = 10;
		[SerializeField]
		public Material[] temp_mat;

		private void Awake()
		{
			_instance = this;
		}

		// Start is called before the first frame update
		void Start()
		{
			Vector3 tmp = Vector3.zero;
			for (int i = 0; i < nb_particle; i++)
			{
				tmp.z = (i / 30) * 2;
				tmp.x = (i  % 30) * 2;
				Instantiate(particle, tmp, Quaternion.identity, this.transform);
			}
		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}