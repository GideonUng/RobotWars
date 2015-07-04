using UnityEngine;
using System.Collections;


public class Weapon : MonoBehaviour {

	public int player;

	public float weaponRotateSpeed = 1000.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float v = weaponRotateSpeed * Input.GetAxis("Fire1P" + player) * Time.deltaTime;
		transform.Rotate(v, 0, 0);
	}


}
