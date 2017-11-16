using UnityEngine;
using System.Collections;

public class HangmanController : MonoBehaviour {

	public GameObject Gantungan, Kepala, Badan, Tangan, Kaki, Muka;

	private GameObject[] parts;
	private int hilangkan;

	public bool isDead {
		get { return hilangkan < 0; } 
	}

	// Use this for initialization
	void Start () {
		parts = new GameObject[] { Muka, Kaki, Tangan, Badan, Kepala, Gantungan};
		reset ();
	}
	
	// Update is called once per frame
	void Update (){
		
	}

	public void hukuman() {
		Debug.Log ("Huruf Salah (menghukum Player :P)");
		if (hilangkan >= 0) {
			parts [hilangkan--].SetActive (true);
		}
	}

	public void reset() {
		if (parts == null)
			return;

		hilangkan = parts.Length - 1;
		foreach (GameObject gk in parts) {
			gk.SetActive (false);
		}
	}
}
