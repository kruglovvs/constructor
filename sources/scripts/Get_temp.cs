using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Get_temp : MonoBehaviour {
	public GameObject last_detail;
	public InputField inputfield;
	private GameObject pole;
	private string detail_parameter;
	private float result;
	private bool key;

	public void Start(){
		pole = GameObject.Find("Pole");
	}

	public void Update(){
		if (last_detail != null) {
			switch (last_detail.name) {
			case "Motor(Clone)":
				key = true;
				detail_parameter = " кг/с";
				break;
			case "Istochnik(Clone)":
				key = true;
				detail_parameter = " Дж/кг";
				break;
			default:
				detail_parameter = " C";
				key=false;
				break;
			}
			if (inputfield.gameObject.activeInHierarchy == false) {
				if (float.TryParse (inputfield.text, out result)) {
					if ((key & result > 0) | (!key&result >= -273)) {
						last_detail.GetComponent<Detail_class> ().parameter = float.Parse (inputfield.text);
						last_detail.transform.GetChild (3).GetComponent<Text> ().text = float.Parse (inputfield.text).ToString () + detail_parameter;
					} else {
						last_detail.GetComponent<Detail_class> ().parameter = -300;
					}
				} else {
					last_detail.GetComponent<Detail_class> ().parameter = -300;
				}
				pole.SetActive (true);
				inputfield.gameObject.SetActive (false);
				inputfield.text = "";
				last_detail = null;
				pole.GetComponent<Retranslater> ().retranslate ();
			}
		}
	}
}
