using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other) {
		TwoDimensionalController controller = other.gameObject.GetComponent<TwoDimensionalController>();
		if(other.tag == "Player"){
			switch(gameObject.name) {
				case "powerUpUp":
					controller.upTurnTime += 1.0f;
					break;
				case "powerUpLeft":
					controller.leftTurnTime += 1.0f;
					break;
				case "powerUpDown":
					controller.downTurnTime += 1.0f;
					break;
				case "powerUpRight":
					controller.rightTurnTime += 1.0f;
					break;
			}
			Destroy(gameObject);
			}
		else{
			Debug.Log(other.tag);
		}
	}
}
