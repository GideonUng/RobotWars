using UnityEngine;
using System.Collections;

public class DamageValues : MonoBehaviour {

	Color textcolor;
	int fadespeed = 2;
	int raisespeed = 10;

	// Use this for initialization
	void Start () {
		textcolor = GetComponent<TextMesh> ().color;
		StartCoroutine("dest");
	}
	
	// Update is called once per frame
	void Update () {
		textcolor = GetComponent<TextMesh> ().color;
		transform.position = new Vector3 (transform.position.x, transform.position.y + raisespeed * Time.deltaTime, transform.position.z);
		GetComponent<TextMesh> ().color = new Color (textcolor.r, textcolor.g, textcolor.b, textcolor.a - fadespeed * Time.deltaTime);
	}

	public void setText(string text){
		GetComponent<TextMesh> ().text = text;
	}

	IEnumerator dest(){
		yield return new WaitForSeconds (5f);
		Destroy (this.gameObject);
	}


}
