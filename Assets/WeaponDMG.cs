using UnityEngine;
using System.Collections;

public class WeaponDMG : MonoBehaviour {

	public int weaponDamage = 10;
	public GameObject hitPrefab;
	public GameObject textPrefab;

	bool weaponEnabled = true;
	bool dmgenabled = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log ("col");
		if ((collision.collider.tag == "Robot_Body" || collision.collider.tag == "Player1" || collision.collider.tag == "Player2") && weaponEnabled && dmgenabled){
			Debug.Log ("dmg");
			collision.collider.gameObject.GetComponent<Damage> ().DealDamage (weaponDamage);
			GameObject hit = Instantiate (hitPrefab, collision.contacts[0].point, Quaternion.identity) as GameObject;

			Destroy (hit, 5f);
			dmgenabled = false;
		}

		if (collision.collider.tag == "Shield" && weaponEnabled) {
			Debug.Log ("Shield");
			GetComponentInParent<RobotMove>().Knockback();
			StartCoroutine ("HitShield");
		}

	}

	void OnCollisionExit(Collision collisionInfo) {
		dmgenabled = true;
	}
	
	IEnumerator HitShield (){
		weaponEnabled = false;
		yield return new WaitForSeconds (0.5f);
		weaponEnabled = true;
	}

}
