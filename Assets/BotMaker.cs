using UnityEngine;
using System.Collections;

public class BotMaker : MonoBehaviour {

	public int player = 1;
	public GameObject spawnPoint;
	public int heads = 1;
	public int weels = 1;
	public int torsos = 1;
	public int arms = 1;
	public int specials = 1;

	int weel = 0;
	int torso = 0;
	int head = 0;
	int leftarm = 0;
	int rightarm = 0;
	int special = 0;
	GameObject robot;

	// Use this for initialization
	void Start () {
		SpawnRobot ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void NewPart(int pos, int part) {
	switch(pos){
		case 0:
			weel += part;
			if (weel > weels)
				weel = 0;
			if (weel < 0)
				weel = weels;
			break;
		case 1:
			torso += part;
			if (torso > weels)
				torso = 0;
			if (torso < 0)
				torso = torsos;
			break;
		case 2:
			head += part;
			if (head > weels)
				head = 0;
			if (head < 0)
				head = weels;
			break;
		case 3:
			leftarm += part;
			if (leftarm > arms)
				leftarm = 0;
			if (leftarm < 0)
				leftarm = arms;
			break;
		
		case 4:
			rightarm += part;
			if (rightarm > arms)
				rightarm = 0;
			if (rightarm < 0)
				rightarm = arms;
			break;

		case 5:
			special += part;
			if (special > specials)
				special = 0;
			if (special < 0)
				special = specials;
			break;
		}
		SpawnRobot ();
	}



	public void SpawnRobot(){
		Debug.Log ("arm" + leftarm.ToString ());
		Debug.Log ("arm" + rightarm.ToString());
		Debug.Log ("...");
		Debug.Log ("head" + head.ToString());
		Debug.Log ("weel" + weel.ToString());
		Debug.Log ("special" + torso.ToString());

		Destroy (GameObject.FindGameObjectWithTag ("Player" + player));

		GameObject robot_weels = Instantiate(Resources.Load("weel" + weel.ToString()), spawnPoint.transform.position, Quaternion.identity) as GameObject;
		robot_weels.GetComponent<RobotMove> ().player = player;
		robot_weels.GetComponent<Damage> ().player = player;

		GameObject robot_special = Instantiate(Resources.Load("special" + special.ToString()), spawnPoint.transform.position + new Vector3(0,0,1), Quaternion.identity) as GameObject;
		robot_special.transform.SetParent (robot_weels.transform);

		GameObject robot_torso = Instantiate(Resources.Load("torso" + torso.ToString()), spawnPoint.transform.position + new Vector3(0,1,0), Quaternion.identity) as GameObject;
		robot_torso.transform.SetParent (robot_weels.transform);
		robot_torso.GetComponent<RotateWeaponsPlatform> ().player = player;
		robot_torso.GetComponent<Damage> ().weels = robot_weels;
		robot_torso.GetComponent<Damage> ().player = player;

		GameObject robot_head = Instantiate(Resources.Load("head" + head.ToString()), spawnPoint.transform.position + new Vector3(0,2,0), Quaternion.identity) as GameObject;
		robot_head.transform.SetParent (robot_torso.transform);
		robot_head.GetComponent<Damage> ().weels = robot_weels;
		robot_head.GetComponent<Damage> ().player = player;

		//actually the right arm
		GameObject robot_left_arm = Instantiate(Resources.Load("arm" + leftarm.ToString()), spawnPoint.transform.position + new Vector3(1,1.2f,0), Quaternion.identity) as GameObject;
		robot_left_arm.GetComponent<Weapon> ().player = player;
		robot_left_arm.transform.localScale = new Vector3 (-1, 1, 1);
		//robot_left_arm.GetComponentInChildren<Weapon>().player = player;
		robot_left_arm.transform.SetParent (robot_torso.transform);

		//actually the left arm	
		GameObject robot_rigth_arm = Instantiate(Resources.Load("arm" + rightarm.ToString()), spawnPoint.transform.position + new Vector3(-1,1.2f,0), Quaternion.identity) as GameObject;
		// 	robot_rigth_arm.transform.localScale = new Vector3 (-1, 1, 1);
		robot_rigth_arm.transform.SetParent (robot_torso.transform);
		robot_rigth_arm.GetComponent<Weapon> ().player = player;

		//robot_rigth_arm.GetComponentInChildren<Weapon>().player = player;
		DontDestroyOnLoad(robot_weels);
		robot_weels.transform.Rotate (0, 135, 0);
		robot_weels.gameObject.tag = "Player" + player;
		robot_weels.name = "Player" + player;

		if (player == 1) {
			GameObject.FindGameObjectWithTag ("_GM").GetComponent<GM>().player1 = robot_weels;
		} else if (player == 2) {
			GameObject.FindGameObjectWithTag ("_GM").GetComponent<GM>().player2 = robot_weels;
		}



	}
}
