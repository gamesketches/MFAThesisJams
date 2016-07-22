using UnityEngine;
using System.Collections;

public class GenLevel : MonoBehaviour {

	

	// Use this for initialization
	void Start () {
		Transform environment = GameObject.Find("Environment").transform;
		GameObject prefab;
		GameObject[] obstacles = Resources.LoadAll<GameObject>("prefabs/LevelPrefabs");
		foreach(GameObject obstacle in obstacles) {
			if(obstacle.tag != "Goal") {
				for(int i = 0; i < 3; i++) {
					prefab = Instantiate(obstacle, new Vector3((Random.value * 12f) - 12f, (Random.value * 12f) - 12f, 0), Quaternion.identity) as GameObject;
					prefab.transform.parent = environment;
				}
			}
			else {
				prefab = Instantiate(obstacle, new Vector3((Random.value * 12f) - 12f, (Random.value * 12f) - 12f, 0), Quaternion.identity) as GameObject;
				prefab.transform.parent = environment;
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
