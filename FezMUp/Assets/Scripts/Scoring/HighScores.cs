using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class HighScores : MonoBehaviour {

	private const string HIGH_SCORE_PATH = "/Scores/";
	public string highScoresFile = "HighScores.txt";
	public string highScoreNamesFile = "HighScoreNames.txt";

	bool highScoresChanged;

	public void RecalculateHighScores()
	{
		int currentScore = GameObject.Find("Canvas").GetComponent<Timer>().TotalTime;

		List<int> highScores = GetOldScores();

		for (int i = 0; i < highScores.Count; i++)
		{
			if (currentScore > highScores[i])
			{
				highScores.Insert(i, currentScore);
				ValueHolder.insertPoint = i;
				UpdateHighScoreList(highScores);
				UpdateHighScoreNames();
				break;
			}
		}

		SceneManager.LoadScene("High scores");
	}

	List<int> GetOldScores()
	{
		string[] oldHighScores = FileIO.SplitStringArrayFromFile(Application.dataPath + HIGH_SCORE_PATH + highScoresFile, ',');
		List<int> oldScores = new List<int>();

		foreach (string value in oldHighScores) { oldScores.Add(int.Parse(value)); }

		return oldScores;
	}
		
	string revisedScores = "";

	void UpdateHighScoreList(List<int> highScores)
	{
		for (int i = 0; i < ValueHolder.scoresTracked; i++)
		{
			revisedScores += highScores[i].ToString() + ",";
		}

		revisedScores = revisedScores.Trim(',');

		FileIO.WriteStringToFile(Application.dataPath + HIGH_SCORE_PATH + highScoresFile,
								 revisedScores,
								 false);
	}

	string revisedNames = "";

	void UpdateHighScoreNames()
	{
		List<string> names = GetOldNames();

		names.Insert(ValueHolder.insertPoint, ValueHolder.name);

		for (int i = 0; i < ValueHolder.scoresTracked; i++)
		{
			revisedNames += names[i] + ",";
		}

		revisedNames = revisedNames.Trim(',');

		FileIO.WriteStringToFile(Application.dataPath + HIGH_SCORE_PATH + highScoreNamesFile,
								 revisedNames,
								 false);
	}

	List<string> GetOldNames()
	{
		string[] oldHighScoreNames = FileIO.SplitStringArrayFromFile(Application.dataPath + HIGH_SCORE_PATH + highScoreNamesFile,
																	 ',');
		List<string> oldNames = new List<string>();

		foreach (string value in oldHighScoreNames) { oldNames.Add(value); }

		return oldNames;
	}
}
