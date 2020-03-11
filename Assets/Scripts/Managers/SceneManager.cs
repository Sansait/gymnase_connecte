using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CRI.ConnectedGymnasium
{
	public class SceneManager : MonoBehaviour
	{
		private static SceneManager _instance;
		public static SceneManager Instance
		{
			get
			{
				if (_instance == null)
					Debug.LogError("Scene Manager is NULL.");
				return (_instance);
			}
		}

		private void Awake()
		{
			_instance = this;
		}

		// GameObjects to pass to other scenes
		[SerializeField] private GameObject players;
		[SerializeField] private GameObject gameManager;

		public IEnumerator LoadAsyncScene(string m_Scene)
		{
			// Set the current Scene to be able to unload it later
			Scene currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();

			// The Application loads the Scene in the background at the same time as the current Scene.
			AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(m_Scene, LoadSceneMode.Additive);

			// Wait until the last operation fully loads to return anything
			while (!asyncLoad.isDone)
			{
				yield return null;
			}

			// Move the GameObjects to the newly loaded Scene
			UnityEngine.SceneManagement.SceneManager.MoveGameObjectToScene(players, UnityEngine.SceneManagement.SceneManager.GetSceneByName(m_Scene));
			UnityEngine.SceneManagement.SceneManager.MoveGameObjectToScene(gameManager, UnityEngine.SceneManagement.SceneManager.GetSceneByName(m_Scene));

			UnityEngine.SceneManagement.SceneManager.SetActiveScene(UnityEngine.SceneManagement.SceneManager.GetSceneByName(m_Scene));

			// Activating scipts for the loaded scene
			GameManager.Instance.LoadScripts(m_Scene);

			// Unload the previous Scene
			asyncLoad = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(currentScene);

			while (!asyncLoad.isDone)
			{
				yield return null;
			}
		}
	}
}