using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

	public int armor = 1;
	public GameObject weels;
	public int player;
	public GameObject textPrefab;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DealDamage (int dmg){
		GameObject.FindGameObjectWithTag ("_GM").GetComponent<GM> ().PlayerTakesDmg (player, dmg / armor);
		GameObject text = Instantiate (textPrefab,	this.transform.position, Quaternion.identity) as GameObject;
		text.GetComponent<DamageValues> ().setText ((dmg / armor).ToString());
	}
}