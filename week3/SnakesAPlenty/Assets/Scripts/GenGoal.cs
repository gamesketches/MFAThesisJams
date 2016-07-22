using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GenGoal : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			Text winText = other.gameObject.transform.parent.GetComponentInChildren<Text>();
			winText.text = "YOU WIN!!";
		}
	}
}
