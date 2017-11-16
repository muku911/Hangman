using UnityEngine;
using System.Collections;

public class levelpick : MonoBehaviour {

	public void level_easy(){
		Application.LoadLevel (2);
	}

	public void level_medium(){
		Application.LoadLevel (4);
	}

	public void level_hard(){
		Application.LoadLevel (3);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
