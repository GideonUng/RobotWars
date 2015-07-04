using UnityEngine;
using System.Collections;

public class RotateWeaponsPlatform : MonoBehaviour {

	public int player;
	public float maxTorsoTurnSpeed = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//float v = maxTorsoTurnSpeed * Input.GetAxis("Horizontal2P"+player) * Time.deltaTime;
		//transform.Rotate(0, v, 0);
	}
}
