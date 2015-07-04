using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;

	public int p1HP = 100;
	public int p2HP = 100;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
		p1HP = 100;
		p2HP = 100;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayerTakesDmg(int player, int dmg){
		Debug.Log ("_GM dmg " + player + ", " + dmg);
		if (player == 1) {
			p1HP -= dmg;
			if (p1HP <= 0)
			{	
				Debug.Log ("1 defeated");
				//Destroy (player1.gameObject,0f);
				player1.GetComponent<Destructor>().Destroy ();
				GameObject.FindGameObjectWithTag("WinText").GetComponent<Text>().text = "Player 2 WINS!";
				restart ();
			}
		} else if (player == 2) {
			p2HP -= dmg;
			if (p2HP <= 0)
			{
				Debug.Log ("2 defeated");
				//Destroy (player2.gameObject,0f);
				player2.GetComponent<Destructor>().Destroy ();
				GameObject.FindGameObjectWithTag("WinText").GetComponent<Text>().text = "Player 1 WINS!";
				restart ();
			}
		}
	}

	public void restart(){


		//GameObject.FindGameObjectWithTag("WinText").GetComponent<Text>().text = "Player "+win+" wins!";
		StartCoroutine("delayedRestart");
	}

	void OnLevelWasLoaded(int level) {
		p1HP = 100;
		p2HP = 100;

		if (level == 1) {
			player1.transform.position = GameObject.FindGameObjectWithTag("Spawn1").transform.position;
			player2.transform.position = GameObject.FindGameObjectWithTag("Spawn2").transform.position;
		}
		
	}
	
	IEnumerator delayedRestart(){
		yield return new WaitForSeconds (5f);

		Application.LoadLevel ("charcreation");
	}
}
