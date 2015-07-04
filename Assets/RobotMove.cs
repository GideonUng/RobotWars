using UnityEngine;
using System.Collections;

public class RobotMove : MonoBehaviour {

	public int player;
	public float maxMoveSpeed = 10.0f;
	public float maxTurnSpeed = 10.0f;
	Vector3 forward;
	GameObject forwardPoint;

	// Use this for initialization

	void Start () {
		forward = Vector3.forward;
		forwardPoint = this.gameObject.transform.GetChild (0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		float h = maxMoveSpeed * Input.GetAxis ("VerticalP" + player);
		//this.transform.position = this.transform.position + (forwardPoint.transform.position - this.transform.position) * Time.deltaTime * h;
		GetComponent<Rigidbody> ().AddForce (Vector3.Normalize (forwardPoint.transform.position - this.transform.position) * h * 50);
		if (GetComponent<Rigidbody> ().velocity.magnitude > maxMoveSpeed)
			GetComponent<Rigidbody> ().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody> ().velocity, maxMoveSpeed);
		float v = maxTurnSpeed * Input.GetAxis ("HorizontalP" + player) * Time.deltaTime;
		transform.Rotate(0, v, 0);
	}

	public void Knockback(){
		GetComponent<Rigidbody> ().AddForce (Vector3.Normalize (transform.position - forwardPoint.transform.position) * 500);
	}


}
