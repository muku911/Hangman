using Util;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public Text kalimatIndikator, scoreIndikator, kataIndikator, winIndikator, keterangan;

	private HangmanController Hangman_;
	private string kalimat;
	private char[] kata;
	private int[] angka;
	private int score, forwin, hidebtn, number;
	private bool NextLevel, NextWord, GameOver;

	public void level_medium(){
		if (forwin == 5) {
			Application.LoadLevel (4);
		} else if (GameOver) {
			Application.LoadLevel (1);
		}
	}
	 
	public void surender(){
		Application.LoadLevel (0);
	}

	// Use this for initialization
	void Start () {
		//
		angka = new int[20];
		for (int x = 1; x <= 10; x++) {
			angka [x] = 0;
		}
		score = 0;
		forwin = 0;
		updateScoreIndikator ();
		random ();

		Hangman_ = GameObject.FindGameObjectWithTag ("Player").GetComponent<HangmanController> ();
	}
	
	// Update is called once per frame
	void Update () {
		//next kata karena salah
		if (NextWord) {
			string temp = Input.inputString;
			random ();
			return;
		} else if (GameOver) {
			kalimatIndikator.text = kalimat;
			winIndikator.text = "GAME OVER";
			keterangan.text = "Back To Menu";
			return;
		}

		if (forwin < 5) { 
			//input
			string s = Input.inputString;
			if (s.Length == 1 && TextUtils.isUAlpha (s [0])) {
				if (!chek (s.ToUpper () [0])) {
					Debug.Log ("Telah Memasukan Huruf " + s);
					Hangman_.hukuman ();

					if (Hangman_.isDead) {
						GameOver = true;
					}
				}
			}
		}
		if (forwin == 5) {
			keterangan.text = "Click To Next Game";
			winIndikator.text = "YOU WIN";
			NextWord = false;
		}
	
	}

	private bool chek(char c){
		bool retrn = false;
		int complete = 0;
		int score = 0;
	
		for (int i = 0; i < kata.Length; i++) {
			if (c == kalimat [i]) {
				retrn = true; 
				if (kata [i] == 0) {
					kata [i] = c;
					score++;
				}
			}
			if (kata [i] != 0)
				complete++;
		}

		if (score != 0) {
			this.score += score;
			if (complete == kata.Length) {
				forwin++;
				this.NextWord = true;
				this.score = score;
				updateScoreIndikator ();
				Hangman_.reset ();
			}
			updateKalimatIndikator ();

		}


		return retrn;
	}

	private void updateScoreIndikator() {
		scoreIndikator.text = "Score : " + forwin;
	}

	private void updateKalimatIndikator() {
		string display = "";

		//Memunculkan kata _ _ _ _
		for (int i = 0; i < kata.Length; i++) {
			char c = kata [i];
			if (c == 0) {
				c = '_';
			}

			display += ' ';
			display += c;
		}

		kalimatIndikator.text = display;
	}

	private void setKalimat(string kalimat, string Hint) {
		kalimat = kalimat.ToUpper ();
		this.kalimat = kalimat;
		kata = new char[kalimat.Length];
		kataIndikator.text = Hint;

		updateKalimatIndikator();
	}

	private void Kata_Kata(int number) {

		NextWord = false;

		if (number == 1 ) setKalimat ("Tahu","...... Bulat Bulat Bulat");
		else if (number == 2 )setKalimat ("Tempe","Teman Makan Nasi Dari Kedelai");
		else if (number == 3 )setKalimat ("Keju","Biasa Untuk Isi Roti");
		else if (number == 4 )setKalimat ("Ayam","Lauk dari Unggas");
		else if (number == 5 )setKalimat ("Donat","Sejenis Roti berbentuk bulats");
		else if (number == 6 )setKalimat ("Telur","Makanan Langganan anak Kos");
		else if (number == 7 )setKalimat ("Gudeg","Nama Lain Sayur Nangka");
		else if (number == 8 )setKalimat ("Soto","Kuahnya Warna kuning");
		else if (number == 9 )setKalimat ("Sate","Ada Tusukannya");
		else if (number == 10 )setKalimat ("sup","Makanan Berkuah Dengan Sayuran");
	}

	private void random() {
		// untuk random //
		number = Random.Range (1, 10);
		cheknumber (number);
	}

	private void cheknumber(int number){
		if (angka [number] == number) {
			random ();
		} else if (angka [number] != number) {
			for (int i = 1; i <= 10; i++) {
				if (i == number)
					angka [i] = number;
			}
			Kata_Kata (number);
		}
	}

}
