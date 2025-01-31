﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
	public GameObject pM;
	public AudioMixerSnapshot paused;
	public AudioMixerSnapshot unpaused;
	bool isPaused = false;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (isPaused)
				Resume();

			else
				Pause();
		}
	}

	public void Pause()
	{
		Time.timeScale = 0;
		isPaused = true;
		pM.gameObject.SetActive(true);
		Cursor.lockState = CursorLockMode.Confined;
		paused.TransitionTo(.01f);
	}
	public void Resume()
	{
		Time.timeScale = 1;
		isPaused = false;
		pM.gameObject.SetActive(false);
		Cursor.lockState = CursorLockMode.Locked;
		unpaused.TransitionTo(.01f);
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void Options()
	{
		PlayerPrefs.SetString("PrevScene", SceneManager.GetActiveScene().name);
		SceneManager.LoadScene("Options");
	}
}
