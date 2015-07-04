using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Destroy(){
		transform.parent = null; // i want to be the very best
		try {
			GetComponent<Rigidbody>().isKinematic = false;
		} catch (System.Exception e){ // like no one ever was
		}
		try {
			GetComponentInChildren<Rigidbody> ().isKinematic = false;
		} catch (System.Exception e){ // to catch them is my real test
		}
		try {
			GetComponentInChildren<Destructor> ().Destroy ();
		} catch (System.Exception e){ // to train them is my cause

		}
	}
}
