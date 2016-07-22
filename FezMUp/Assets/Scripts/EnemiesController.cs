using UnityEngine;
using System.Collections;

public class EnemiesController : MonoBehaviour 
{
	public float speed;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//move the enemies
		this.gameObject.transform.position -= new Vector3(speed * Time.deltaTime, 0f,0f);

		//check the most front enemy
		CheckEnemyPosition();
	}

	void CheckEnemyPosition ()
	{
		if (this.gameObject.transform.GetChild(0).gameObject.transform.position.x <= -19f)
		{
			//destroy it
			Destroy (this.gameObject.transform.GetChild(0).gameObject);
		
			//spawn a new one
			SpawnEnemy();
		}
	}

	void SpawnEnemy ()
	{
		
	}
}
