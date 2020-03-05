using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public Rigidbody rb;
	public float speed = 500f;
	public int health = 5;
	private int score = 0;
	public Text scoreText;
	public Text healthText;
	public Text winLoseText;
	public Image winLoseBG;

	void Start()
	{
		winLoseBG.enabled = false;
	}
	void Update()
	{
		if (health == 0)
		{
			// Debug.Log("Game Over!");
			winLoseBG.enabled = true;
			Death();
			StartCoroutine(LoadScene(3));
		}
	}
	void FixedUpdate()
	{
		if (Input.GetKey("w"))
		{
			rb.AddForce(0, 0, speed * Time.deltaTime);
		}
		if (Input.GetKey("a"))
		{
			rb.AddForce((-1 * speed) * Time.deltaTime, 0, 0);
		}
		if (Input.GetKey("s"))
		{
			rb.AddForce(0, 0, (-1 * speed) * Time.deltaTime);
		}
		if (Input.GetKey("d"))
		{
			rb.AddForce(speed * Time.deltaTime, 0, 0);
		}
		if (Input.GetKey("escape"))
		{
			SceneManager.LoadScene(0);
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Pickup")
		{
			score += 1;
			SetScoreText();
			// Debug.Log("Score: " + score);
			Destroy(other.gameObject);
		}
		if (other.tag == "Trap")
		{
			health -= 1;
			SetHealthText();
			// Debug.Log("Health: " + health);
		}
		if (other.tag == "Goal")
		{
			winLoseBG.enabled = true;
			SetWin();
			// Debug.Log("You win!");
		}
	}
	void SetScoreText()
	{
		scoreText.text = "Score: " + score.ToString();
	}
	void SetHealthText()
	{
		healthText.text = "Health: " + health.ToString();
	}
	void SetWin()
	{
		winLoseText.text = "You Win!";
		winLoseText.color = Color.black;
		winLoseBG.color = Color.green;
	}
	void Death()
	{
		winLoseText.text = "Game Over!";
		winLoseText.color = Color.white;
		winLoseBG.color = Color.red;
		health = 5;
		score = 0;
	}
	IEnumerator LoadScene(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
