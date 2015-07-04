using UnityEngine;
using System.Collections;

public class Done : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void done(){
		if (GameObject.FindGameObjectWithTag ("BotMaker").GetComponent<BotMaker> ().player == 1) {
			GameObject.FindGameObjectWithTag ("BotMaker").GetComponent<BotMaker> ().player ++;
			GameObject.FindGameObjectWithTag ("Player1").transform.position = new Vector3(11,0,11);
			GameObject.FindGameObjectWithTag ("BotMaker").GetComponent<BotMaker>().SpawnRobot();
		} else {
			Application.LoadLevel("combatTest");
		}

	}

}
