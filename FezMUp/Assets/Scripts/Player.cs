using UnityEngine;
using System.Collections;
using Holoville.HOTween;
using Holoville.HOTween.Plugins; 

public class Player : MonoBehaviour 
{
	//character speed when moving
	public float speed;

	private BoxCollider collider;
	//To know whether the switching is still on process or not
	private bool isSwitchingHappening; 

	// Use this for initialization
	void Start () 
	{
		GameManager.instance.xyMode = true;

		collider = GetComponent<BoxCollider>();
		collider.size = new Vector3(1, 1, 100);

		for (int i = 0; i < GameManager.instance.enemiesGroup.transform.GetChild(0).gameObject.transform.childCount; i++) 
		{
			GameObject enemy = GameManager.instance.enemiesGroup.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject;

			enemy.GetComponent<BoxCollider> ().size = new Vector3 (1, 1, 100);
		}
	}
	
	void OnPlayerRotationFinished ()
	{
		if (GameManager.instance.xyMode)
		{
			collider.size = new Vector3(1, 100, 1);

			//change the enemies collider
			ChangeEnemiesCollider(GameManager.instance.xyMode);
		}
		else
		{
			collider.size = new Vector3(1, 1, 100);

			//change the enemies collider
			ChangeEnemiesCollider(GameManager.instance.xyMode);
		}

		GameManager.instance.xyMode = !GameManager.instance.xyMode;

		isSwitchingHappening = false;
	}
	
	/*void OnEnemiesRotationFinished ()
	{

	}*/

	void ChangeEnemiesCollider (bool xyMode)
	{
		if (GameManager.instance.xyMode)
		{
			for (int i = 0; i < GameManager.instance.enemiesGroup.transform.GetChild(0).gameObject.transform.childCount; i++) 
			{
				GameObject enemy = GameManager.instance.enemiesGroup.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject;
	
				enemy.GetComponent<BoxCollider> ().size = new Vector3 (1, 100, 1);
			}
		}
		else
		{
			for (int i = 0; i < GameManager.instance.enemiesGroup.transform.GetChild(0).gameObject.transform.childCount; i++) 
			{
				GameObject enemy = GameManager.instance.enemiesGroup.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject;
	
				enemy.GetComponent<BoxCollider> ().size = new Vector3 (1, 1, 100);
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		//change dimension
		if(Input.GetKeyDown(KeyCode.Space) && !isSwitchingHappening) 
		{
			if(GameManager.instance.xyMode) 
			{
				isSwitchingHappening = true;

				//rotate the player and enemies to x rotation to 0
				HOTween.To(this.gameObject.transform.parent.gameObject.transform, 0.5f, new TweenParms().Prop("localRotation", new Vector3(-90f,0f,0f), false).OnComplete(OnPlayerRotationFinished).Ease(EaseType.Linear).Delay(0f));
				HOTween.To(GameManager.instance.enemiesGroup.transform, 0.5f, new TweenParms().Prop("localRotation", new Vector3(-90f,0f,0f), false).Ease(EaseType.Linear).Delay(0f));
			}
			else 
			{
				isSwitchingHappening = true;

				//rotate the player and enemies to x rotation to 0
				HOTween.To(this.gameObject.transform.parent.gameObject.transform, 0.5f, new TweenParms().Prop("localRotation", new Vector3(0f,0f,0f), false).OnComplete(OnPlayerRotationFinished).Ease(EaseType.Linear).Delay(0f));
				HOTween.To(GameManager.instance.enemiesGroup.transform, 0.5f, new TweenParms().Prop("localRotation", new Vector3(0f,0f,0f), false).Ease(EaseType.Linear).Delay(0f));
			}
		}

		//not receiving input movement when switching is happening
		if (!isSwitchingHappening)
			{
			if (Input.GetKey(KeyCode.W))
			{
				this.gameObject.transform.position += new Vector3(0f, 1f, 0f) * speed * Time.deltaTime;
			}
			//else
			if (Input.GetKey(KeyCode.S))
			{
				this.gameObject.transform.position += new Vector3(0f, -1f, 0f) * speed * Time.deltaTime;
			}
			//else
			if (Input.GetKey(KeyCode.A))
			{
				this.gameObject.transform.position += new Vector3(-1f, 0f, 0f) * speed * Time.deltaTime;
			}
			//else
			if (Input.GetKey(KeyCode.D))
			{
				this.gameObject.transform.position += new Vector3(1f, 0f, 0f) * speed * Time.deltaTime;
			}
		}

		if (this.gameObject.transform.position.x <= -9.4f)
		{
			this.gameObject.transform.position = new Vector3(-9.4f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
		}

		if (this.gameObject.transform.position.x >= 9.4f)
		{
			this.gameObject.transform.position = new Vector3(9.4f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
		}

		if (this.gameObject.transform.position.y >= 5.2f)
		{
			this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 5.2f, this.gameObject.transform.position.z);
		}

		if (this.gameObject.transform.position.y <= -5.2f)
		{
			this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, -5.2f, this.gameObject.transform.position.z);
		}
	}

	void OnTriggerEnter (Collider coll)
	{
		//if hits an enemy while switching is not happening
		if (coll.gameObject.tag == "Enemy" && !isSwitchingHappening)
		{
			//pause the game
			Time.timeScale = 0f;

			//GameObject.Find("SceneManager").GetComponent<HighScores>().RecalculateHighScores();

			StartCoroutine(GoToHighScores());

			Debug.Log("Touched an enemy");
		}
	}

	public float endGameDelay = 2.0f;

	IEnumerator GoToHighScores()
	{
		float start = Time.realtimeSinceStartup;

		while (Time.realtimeSinceStartup < start + endGameDelay)
		{
			yield return null;
		}

		GameObject.Find("SceneManager").GetComponent<HighScores>().RecalculateHighScores();

		yield break;
	}
}
