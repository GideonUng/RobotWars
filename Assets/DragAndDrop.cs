using UnityEngine;
using System.Collections;

public class DragAndDrop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDrag () {
		this.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,0,Camera.main.ScreenToWorldPoint(Input.mousePosition).z);

	}
}
