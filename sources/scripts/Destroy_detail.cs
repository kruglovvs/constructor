using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_detail : MonoBehaviour {
	public GameObject last_detail;
	public GameObject delete;
	private GameObject pole;
	public GameObject change_buttom;
	public GameObject inputfield;

	public void Start(){
		pole = GameObject.Find ("Pole");
	}

	public void Update () {
		if (last_detail != null) {
			if (delete.activeInHierarchy == false) {
				List<Transform> _input = last_detail.GetComponent<Detail_class> ().input;
				for (int i2 = 0; i2 < _input.Count; i2++) {
					List<Transform> _input_output = _input [i2].parent.GetComponent<Detail_class> ().output;
					for (int i21 = 0; i21 < _input_output.Count; i21++) {
						if (_input_output [i21].parent.gameObject == last_detail) {
							_input [i2].parent.GetComponent<Detail_class> ().output.Remove (_input_output [i21]);
						}
					}
				}
				List<Transform> _output = last_detail.GetComponent<Detail_class> ().output;
				for (int i3 = 0; i3 < _output.Count; i3++) {
					List<Transform> _output_input = _output [i3].parent.GetComponent<Detail_class> ().input;
					for (int i31 = 0; i31 < _output_input.Count; i31++) {
						if (_output_input [i31].parent.gameObject == last_detail) {
							_output [i3].parent.GetComponent<Detail_class> ().input.Remove (_output_input [i31]);
						}
					}
				}
				for (int i = 0; i < last_detail.GetComponent<Detail_class> ().lines.Count; i++) {
					Destroy (last_detail.GetComponent<Detail_class> ().lines [i]);
				}
				Destroy (last_detail);
				change_buttom.SetActive (false);
				inputfield.gameObject.SetActive (false);
				last_detail = null;
				pole.GetComponent<Retranslater> ().retranslate ();
			}
		}
	}
}
