using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour {

	public static GameplayController instance;

	private Text coinText, healthText, timerText;

	private int coinScore;

	[HideInInspector]
	public bool isPlayerAlive;

	public float timerTime = 99f;
	
	void Awake () {
		makeInstance();

		coinText = GameObject.Find("CoinText").GetComponent<Text>();
		healthText = GameObject.Find("HealthText").GetComponent<Text>();
		timerText = GameObject.Find("TimerText").GetComponent<Text>();

		coinText.text = "Coins: " + coinScore;
	}

	void Start()
    {
		isPlayerAlive = true;

    }

	void Update()
    {
		countdownTimer();
    }

	void makeInstance()
    {
		if (instance == null)
        {
			instance = this;
        }
		else if (instance != null)
        {
			Destroy(gameObject);
        }
    }

	public void CoinCollected()
    {
		coinScore++;
		coinText.text = "Coins: " + coinScore;
    }

	public void DisplayHealth(int health)
    {
		healthText.text = "Health: " + health;
    }

	void countdownTimer()
    {
		timerTime -= Time.deltaTime;

		timerText.text = "Time: " + timerTime.ToString("F0");
    }
}
