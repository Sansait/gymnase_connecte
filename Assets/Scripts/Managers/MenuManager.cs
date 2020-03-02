using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CRI.ConnectedGymnasium
{
	public class MenuManager : MonoBehaviour
	{
		// Menu gameObjects
		[SerializeField] private GameObject playMenu;
		[SerializeField] private GameObject mainMenu;
		[SerializeField] private GameObject calibrationMenu;
		[SerializeField] private GameObject exitMenu;

		// Button gameObjects
		[SerializeField] private Button playButton;
		[SerializeField] private Button calibrationButton;
		[SerializeField] private Button calibrateButton;
		[SerializeField] private Button backButtonPlay;
		[SerializeField] private Button backButtonCalibrate;
		[SerializeField] private Button pongButton;
		[SerializeField] private Button mazeButton;
		[SerializeField] private Button exitButton;
		[SerializeField] private Button yesButton;
		[SerializeField] private Button backExitButton;


		// Calibration gameObject
		[SerializeField] private GameObject calibrationGO;

		// Linking every button to it's listener
		void Awake()
		{
			playButton.onClick.AddListener(PlayButtonListener);
			pongButton.onClick.AddListener(PongButtonListener);
			mazeButton.onClick.AddListener(MazeButtonListener);
			backButtonPlay.onClick.AddListener(BackButtonPlayListener);
			calibrationButton.onClick.AddListener(CalibrationButtonListener);
			calibrateButton.onClick.AddListener(CalibrateButtonListener);
			backButtonCalibrate.onClick.AddListener(BackButtonCalibrateListener);
			exitButton.onClick.AddListener(ExitButtonListener);
			yesButton.onClick.AddListener(YesExitButtonListener);
			backExitButton.onClick.AddListener(BackExitButtonListener);
		}

		void PlayButtonListener()
		{
			mainMenu.SetActive(false);
			playMenu.SetActive(true);
		}

		void BackButtonPlayListener()
		{
			mainMenu.SetActive(true);
			playMenu.SetActive(false);
		}

		void BackButtonCalibrateListener()
		{
			mainMenu.SetActive(true);
			calibrationMenu.SetActive(false);
			calibrationGO.SetActive(false);
		}

		void CalibrationButtonListener()
		{
			mainMenu.SetActive(false);
			calibrationMenu.SetActive(true);
			calibrationGO.SetActive(true);
		}

		void CalibrateButtonListener()
		{
			calibrationGO.GetComponent<Calibration>().Calibrate();
			mainMenu.SetActive(true);
			calibrationMenu.SetActive(false);
		}

		void PongButtonListener()
		{
			StartCoroutine(SceneManager.Instance.LoadAsyncScene("Pong"));
		}

		void MazeButtonListener()
		{
			StartCoroutine(SceneManager.Instance.LoadAsyncScene("Maze"));
		}

		void ExitButtonListener()
		{
			mainMenu.SetActive(false);
			exitMenu.SetActive(true);
		}

		void YesExitButtonListener()
		{
			Application.Quit();
		}

		void BackExitButtonListener()
		{
			exitMenu.SetActive(false);
			mainMenu.SetActive(true);
		}
	}
}