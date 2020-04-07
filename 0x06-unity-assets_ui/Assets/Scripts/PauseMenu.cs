using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	public GameObject pM;
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
	}
	public void Resume()
	{
		Time.timeScale = 1;
		isPaused = false;
		pM.gameObject.SetActive(false);
		Cursor.lockState = CursorLockMode.Locked;
	}
}
