using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{

	void Update()
	{
		if (EventSystem.current.currentSelectedGameObject.name == "BackButton")
			Back();
	}
	public void Back()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}
}
