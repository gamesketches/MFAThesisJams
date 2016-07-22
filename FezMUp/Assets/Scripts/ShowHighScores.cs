using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShowHighScores : MonoBehaviour {

	private const string HIGH_SCORE_PATH = "/Scores/";
	public string highScoresFile = "HighScores.txt";
	public string highScoreNamesFile = "HighScoreNames.txt";

	GameObject entry;

	void Start()
	{
		entry = Resources.Load("Entry") as GameObject;
		//Dictionary<string, int> entries = FindEntries();
		//DisplayEntries(entries);
		string[] names = FileIO.SplitStringArrayFromFile(Application.dataPath + HIGH_SCORE_PATH + highScoreNamesFile, ',');
		string[] scoresAsString = FileIO.SplitStringArrayFromFile(Application.dataPath + HIGH_SCORE_PATH + highScoresFile, ',');

		int[] scoresAsInt = TurnScoresToInt(scoresAsString);
		DisplayEntries(names, scoresAsInt);
	}

	int[] TurnScoresToInt(string[] scoresAsString)
	{
		int[] scores = new int[scoresAsString.Length];

		for (int i = 0; i < scoresAsString.Length; i++)
		{
			scores[i] = int.Parse(scoresAsString[i]);
		}

		return scores;
	}

	/*Dictionary<string, int> FindEntries()
	{
		string[] names = FileIO.SplitStringArrayFromFile(Application.dataPath + HIGH_SCORE_PATH + highScoreNamesFile, ',');
		string[] scores = FileIO.SplitStringArrayFromFile(Application.dataPath + HIGH_SCORE_PATH + highScoresFile, ',');

		Dictionary<string, int> entries = new Dictionary<string, int>();

		for (int i = 0; i < ValueHolder.scoresTracked; i++)
		{
			entries.Add(names[i], int.Parse(scores[i]));
		}

		return entries;
	}*/

	public float offset = 1.0f; //offset must be negative, or else high scores will display with lowest score on top!
	public float xStartPos = 0.0f;
	public float yStartPos = 0.0f;

	/*void DisplayEntries(Dictionary<string, int> entries)
	{
		int numEntries = 0;

		foreach (string name in entries.Keys)
		{
			GameObject highScoreLine = Instantiate(entry, new Vector3(xStartPos, yStartPos, 0.0f), Quaternion.identity) as GameObject;
			highScoreLine.transform.SetParent(transform.root.Find("High scores"), false);

			//reposition the entry
			highScoreLine.transform.localPosition = new Vector3(0.0f, 0.0f + offset * numEntries, 0.0f);
			numEntries++;

			highScoreLine.transform.FindChild("Name").GetComponent<Text>().text = name;

			TurnScoreIntoTime(highScoreLine, entries[name]);
		}
	}*/

	void DisplayEntries(string[] names, int[] scores) //names.Length must equal scores.Length
	{
		if (names.Length != scores.Length) { Debug.Log("names.Length != scores.Length"); }

		int numEntries = 0;

		for (int i = 0; i < names.Length; i++)
		{
			GameObject highScoreLine = Instantiate(entry, new Vector3(xStartPos, yStartPos, 0.0f), Quaternion.identity) as GameObject;
			highScoreLine.transform.SetParent(transform.root.Find("High scores"), false);

			//reposition the entry
			highScoreLine.transform.localPosition = new Vector3(0.0f, 0.0f + offset * numEntries, 0.0f);
			numEntries++;

			highScoreLine.transform.FindChild("Name").GetComponent<Text>().text = names[i];
			TurnScoreIntoTime(highScoreLine, scores[i]);
		}
	}

	void TurnScoreIntoTime(GameObject highScoreLine, int score)
	{
		Text secs1sText = highScoreLine.transform.FindChild("secs1s").GetComponent<Text>();
		Text secs10sText = highScoreLine.transform.FindChild("secs10s").GetComponent<Text>();
		Text mins1sText = highScoreLine.transform.FindChild("mins1s").GetComponent<Text>();
		Text mins10sText = highScoreLine.transform.FindChild("mins10s").GetComponent<Text>();

		int secs1s = 0;
		int secs10s = 0;
		int mins1s = 0;
		int mins10s = 0;

		while (score > 0)
		{
			score--;

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

		secs1sText.text = secs1s.ToString();
		secs10sText.text = secs10s.ToString();
		mins1sText.text = mins1s.ToString();
		mins10sText.text = mins10s.ToString();
	}
}
