using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	public Canvas pM;
	bool isPaused = false;
	void Update()
	{
		if (Input.GetKey("escape"))
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
	}
	public void Resume()
	{
		Time.timeScale = 1;
		isPaused = false;
		pM.gameObject.SetActive(false);
	}
}
