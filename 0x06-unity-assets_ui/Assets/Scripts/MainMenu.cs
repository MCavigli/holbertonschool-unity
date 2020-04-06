using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
	// void Start()
	// {
	// 	var aScene = SceneManager.GetActiveScene().buildIndex;
	// }
	void Update()
	{
		// if (Input.GetMouseButtonDown(0))
		// {
		// Debug.Log(aScene);
		// Debug.Log(EventSystem.current.currentSelectedGameObject.name);
		// }
		if (EventSystem.current.currentSelectedGameObject.name == "Level01")
			LevelSelect(0);
		if (EventSystem.current.currentSelectedGameObject.name == "Level02")
			LevelSelect(1);
		if (EventSystem.current.currentSelectedGameObject.name == "Level03")
			LevelSelect(2);
		if (EventSystem.current.currentSelectedGameObject.name == "OptionsButton")
			Options();
		if (EventSystem.current.currentSelectedGameObject.name == "ExitButton")
		{
			Application.Quit();
			Debug.Log("Exited");
		}
	}
	public void LevelSelect(int level)
	{
		SceneManager.LoadScene(level);
	}
	public void Options()
	{

		SceneManager.LoadScene(4);
	}
}
