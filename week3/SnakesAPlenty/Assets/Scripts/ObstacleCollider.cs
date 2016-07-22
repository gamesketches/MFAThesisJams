using UnityEngine;
using System.Collections;

public enum Obstacle {Moutain, River};

public class ObstacleCollider : MonoBehaviour {

	public Obstacle obstacleType;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
		if(other.tag == "Player") {
			other.gameObject.GetComponent<TwoDimensionalController>().speed = 1;
		}

	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.tag == "Player") {
			other.gameObject.GetComponent<TwoDimensionalController>().speed = 3;
		}
	}
}
