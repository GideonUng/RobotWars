using UnityEngine;
using System.Collections;

public class DestroyRobot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Destroy(){
		Rigidbody [] rigids = GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody rigid in rigids) {
			rigid.useGravity = true;
			rigid.freezeRotation = false;
			GameObject.FindGameObjectWithTag("_GM").GetComponent<GM>().restart ();
		}
	}
}
