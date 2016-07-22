using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	float timer = 0.0f;
	int totalTime = 0;
	public int TotalTime { get { return totalTime; } }

	int secs1s = 0;
	int secs10s = 0;
	int mins1s = 0;
	int mins10s = 0;

	Text secs1sDisplay;
	Text secs10sDisplay;
	Text mins1sDisplay;
	Text mins10sDisplay;

	void Start()
	{
		secs1sDisplay = GameObject.Find("secs1s").GetComponent<Text>();
		secs10sDisplay = GameObject.Find("secs10s").GetComponent<Text>();
		mins1sDisplay = GameObject.Find("mins1s").GetComponent<Text>();
		mins10sDisplay = GameObject.Find("mins10s").GetComponent<Text>();
	}

	void Update()
	{
		timer += Time.deltaTime;

		if (timer >= 1.0f)
		{
			TickUp();
			ChangeDisplay();
			totalTime++;
			timer = 0.0f;
		}
	}

	void TickUp()
	{
		secs1s++;

		if (secs1s > 9)
		{
			secs10s++;
			secs1s = 0;
		}

		if (secs10s > 5)
		{
			mins1s++;
			secs10s = 0;
		}

		if (mins1s > 9)
		{
			mins10s++;
			mins1s = 0;
		}
	}

	void ChangeDisplay()
	{
		secs1sDisplay.text = secs1s.ToString();
		secs10sDisplay.text = secs10s.ToString();
		mins1sDisplay.text = mins1s.ToString();
		mins10sDisplay.text = mins10s.ToString();
	}
}
