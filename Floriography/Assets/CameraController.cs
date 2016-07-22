using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	GameObject Player;
	GameObject Bee;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
		Bee = GameObject.FindGameObjectWithTag("Bee");
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(Bee.transform);
	}
}
