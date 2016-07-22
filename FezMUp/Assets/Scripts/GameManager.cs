using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public static GameManager instance;
	
	[HideInInspector]
	public GameObject enemiesGroup;
	
	[HideInInspector]
	public bool xyMode; //To know whether the rotation mode is on or not

	// Use this for initialization
	void Awake () 
	{
		instance = this;

		enemiesGroup = GameObject.Find("Enemies");

		/*foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("xy")) {
			enemy.GetComponent<BoxCollider> ().size = new Vector3 (1, 1, 100);
		}
		foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("xz")) {
			enemy.GetComponent<BoxCollider> ().size = new Vector3 (1, 100, 1);
		}
		foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("yz")) {
			enemy.GetComponent<BoxCollider> ().size = new Vector3 (100, 1, 1);
		}*/
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
