using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
	public void Back()
	{
		SceneManager.LoadScene(PlayerPrefs.GetString("PrevScene"));
	}
}
