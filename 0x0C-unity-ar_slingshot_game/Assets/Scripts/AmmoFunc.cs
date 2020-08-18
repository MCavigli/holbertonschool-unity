using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.Audio;

/// <summary>
/// The game's functionality. WIP!
/// </summary>
public class AmmoFunc : MonoBehaviour
{
	// PRIVATE VARIABLES

	/// <summary>
	/// Raycast manager component
	/// </summary>
	ARRaycastManager m_RaycastManager;

	/// <summary>
	/// Reference manager componenet
	/// </summary>
	ARReferencePointManager m_ReferencePoint;

	/// <summary>
	/// List that holds the results of a raycast hit
	/// </summary>
	List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

	/// <summary>
	/// Predefined pose to make sure the ammo is offset to the camera
	/// </summary>
	Pose ammoPose = new Pose(new Vector3(0.0f, 0.0f, 0.3f), Quaternion.identity);

	/// <summary>
	/// The center position of the ammo. This needs work!
	/// </summary>
	Vector3 centerPos;

	/// <summary>
	/// A reference to this script
	/// </summary>
	AmmoFunc ammoFuncScript;

	/// <summary>
	/// A reference to selectPlane script
	/// </summary>
	SelectPlane selectPlaneScript;

	/// <summary>
	/// A flag that detects when the player is out of ammo
	/// </summary>
	bool outOfAmmo = false;

	/// <summary>
	/// A general flag that makes a reference point and populates a piece of ammo
	/// </summary>
	int flag = 0;

	/// <summary>
	/// The player's score
	/// </summary>
	int score = 0;

	// PUBLIC VARIABLES

	/// <summary>
	/// The GameObject representation of ammo taken from the reference pointf
	/// </summary>
	public GameObject ammo;

	/// <summary>
	/// Game UI for different scenarios
	/// </summary>
	public GameObject gameCanvas;
	public GameObject quitCanvas;
	public GameObject replayCanvas;

	/// <summary>
	/// Each bullet in the ammo count
	/// </summary>
	public GameObject bullet1;
	public GameObject bullet2;
	public GameObject bullet3;
	public GameObject bullet4;
	public GameObject bullet5;
	public GameObject bullet6;
	public GameObject bullet7;

	/// <summary>
	/// Displays player's score
	/// </summary>
	public Text scoreText;

	/// <summary>
	/// The prefab to spawn at the reference point
	/// </summary>
	public ARReferencePoint spawnedObjectRef;

	/// <summary>
	/// A reference to the main camera
	/// </summary>
	public Camera mainCamera;

	public AudioSource introMusic;
	public AudioSource ammoPickup;
	public AudioSource ammoDrop;
	public AudioSource gameOver;

	/// <summary>
	/// Component references and scripts get initialized
	/// </summary>
	void Awake()
	{
		m_RaycastManager = GetComponent<ARRaycastManager>();
		m_ReferencePoint = GetComponent<ARReferencePointManager>();
		ammoFuncScript = GetComponent<AmmoFunc>();
		selectPlaneScript = GetComponent<SelectPlane>();
		introMusic.Play();
	}

	/// <summary>
	/// Runs once per frame
	/// </summary>
	void FixedUpdate()
	{
		// Checks to see if player is out of ammo. If so, triggers the replay canvas
		if (outOfAmmo)
		{
			gameOver.Play();
			replayCanvas.SetActive(true);
		}

		// Runs only once to make the reference point for the ammo the player interacts with.
		// It sets the spawned prefab as a child of the camera, then we save that child as a
		// game object - ammo. Center position of ammo is also set.
		if (flag == 0)
		{
			gameCanvas.SetActive(true);
			spawnedObjectRef = m_ReferencePoint.AddReferencePoint(ammoPose);
			spawnedObjectRef.transform.SetParent(mainCamera.transform, false);
			ammo = mainCamera.gameObject.transform.GetChild(0).gameObject;
			centerPos = spawnedObjectRef.transform.position;
			flag = 1;
		}

		// Detects if player touches the screen.
		if (spawnedObjectRef && Input.touchCount > 0)
		{
			ammoPickup.Play();
			if ((Input.GetTouch(0).phase == TouchPhase.Moved))
			{
				Touch touch = Input.GetTouch(0);

				if (m_RaycastManager.Raycast(touch.position, s_Hits, TrackableType.FeaturePoint))
				{
					ammo.transform.position = s_Hits[0].pose.position + Vector3.zero;
				}
			}

			// Occurs when player releases the ammo
			if (Input.GetTouch(0).phase == TouchPhase.Ended)
			{
				ammoDrop.Play();
				ammo.transform.position = centerPos;
				scoreText.text = "Score: " + score.ToString();
				score += 5;
				if (bullet7.activeSelf)
					bullet7.SetActive(false);
				else if (bullet6.activeSelf)
					bullet6.SetActive(false);
				else if (bullet5.activeSelf)
					bullet5.SetActive(false);
				else if (bullet4.activeSelf)
					bullet4.SetActive(false);
				else if (bullet3.activeSelf)
					bullet3.SetActive(false);
				else if (bullet2.activeSelf)
					bullet2.SetActive(false);
				else if (bullet1.activeSelf)
				{
					bullet1.SetActive(false);
					outOfAmmo = true;
				}
			}
		}
	}

	/// <summary>
	/// Restarts the game by reseting everything score and ammo count
	/// </summary>
	public void restartGame()
	{
		scoreText.text = "Score: 0";
		score = 0;
		bullet1.SetActive(true);
		bullet2.SetActive(true);
		bullet3.SetActive(true);
		bullet4.SetActive(true);
		bullet5.SetActive(true);
		bullet6.SetActive(true);
		bullet7.SetActive(true);
		outOfAmmo = false;
		if (replayCanvas.activeSelf)
			replayCanvas.SetActive(false);
	}

	/// <summary>
	/// Disaplays the quit game canvas
	/// </summary>
	public void quitGame()
	{
		gameCanvas.SetActive(false);
		quitCanvas.SetActive(true);
	}

	/// <summary>
	/// Quits the game if the player confirms they want to quit
	/// </summary>
	public void quitYes()
	{
		Application.Quit();
	}

	/// <summary>
	/// Goes back to the game if the user decides they don't want to quit
	/// </summary>
	public void quitNo()
	{
		gameCanvas.SetActive(true);
		quitCanvas.SetActive(false);
	}
}
