using CRI.HitBoxTemplate.Example;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CRI.ConnectedGymnasium
{
	public class GameManager : MonoBehaviour
	{
		private static GameManager _instance;
		public static GameManager Instance
		{
			get
			{
				if (_instance == null)
					Debug.LogError("Game Manager is NULL.");
				return (_instance);
			}
		}

		private void Awake()
		{
			_instance = this;
		}

		public void LoadScripts(string m_Scene)
		{
			switch (m_Scene)
			{
				case "Main Menu":
					UnloadScripts();
					break;

				case "PongUpgrade":
					PongScripts();
					break;

				case "Maze":
					MazeScripts();
					break;

				case "Barycentre":
					BaryScripts();
					break;
			}
		} 

		public void MazeScripts()
		{
			foreach (var player in PlayerManager.Instance._players)
			{
				player.GetComponent<PlayerPos_Maze>().enabled = true;
			}
		}

		public void BaryScripts()
		{
			foreach (var player in PlayerManager.Instance._players)
			{
				player.GetComponent<Bary_PlayerPos>().enabled = true;
			}
		}

		public void PongScripts()
		{
			foreach (var player in PlayerManager.Instance._players)
			{
				player.GetComponent<PlayerPos_Pong>().enabled = true;
			}
		}

		public void UnloadScripts()
		{
			foreach (var player in PlayerManager.Instance._players)
			{
				player.GetComponent<PlayerPos_Pong>().enabled = false;
				player.GetComponent<PlayerPos_Maze>().enabled = false;
				player.GetComponent<Bary_PlayerPos>().enabled = false;
			}
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				if (UnityEngine.SceneManagement.SceneManager.GetActiveScene() != UnityEngine.SceneManagement.SceneManager.GetSceneByName("Main Menu"))
					StartCoroutine(SceneManager.Instance.LoadAsyncScene("Main Menu"));
			}
		}
	}
}
