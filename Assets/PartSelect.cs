using UnityEngine;
using System.Collections;

public class PartSelect : MonoBehaviour {

	public int pos;
	public GameObject roboBulder;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PartUP(){
		roboBulder.GetComponent<BotMaker> ().NewPart (pos, +1);
	}
	public void PartDown(){
		roboBulder.GetComponent<BotMaker> ().NewPart (pos, -1);
	}
}
