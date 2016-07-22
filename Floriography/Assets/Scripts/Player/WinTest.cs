using UnityEngine;
using System.Collections;

public class WinTest : MonoBehaviour {

	WinLoseManager winLoseManager;

	public void InitializeVariables()
	{
		winLoseManager = transform.root.Find("Scene manager").GetComponent<WinLoseManager>();
		Debug.Log(winLoseManager);
	}

	void OnTriggerEnter(Collider other)
	{
		
		if (other.transform.name.Contains("Bee")) { 
			Debug.Log (other.transform.name);
			StartCoroutine (winLoseManager.PlayerWins ());
		}
	}
}
