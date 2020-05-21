using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;


public class ButtonPress : MonoBehaviour
{
	// public Button twitter;
	// public Button insta;
	// public Button spotify;
	// public Button linkedin;

	public void OpenTwitter()
	{
		Application.OpenURL("https://twitter.com/MarcCavigli");
	}

	public void OpenInsta()
	{
		Application.OpenURL("https://www.instagram.com/marccavigli/");
	}

	public void OpenSpotify()
	{
		Application.OpenURL("https://open.spotify.com/album/1vPG9XrzrfBKdfq1vUgiJH?si=cr5VLATTSYuBL2buA7ytkw");
	}

	public void OpenLinkedin()
	{
		Application.OpenURL("https://www.linkedin.com/in/marccavigli/");
	}
}
