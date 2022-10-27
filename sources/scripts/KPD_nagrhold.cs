using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class KPD_nagrhold : MonoBehaviour {
	private float temp1;
	private float temp2;
	private int count1;
	private int count2;

	public void check () {
		temp2 = -300;
		temp1 = -300;
		count1 = 0;
		count2 = 0;
		if (GetComponent<Detail_class> ().output.Count != 0 & GetComponent<Detail_class> ().input.Count != 0) {
			List<Transform> _out = GetComponent<Detail_class> ().output;
			for (int i1 = 0; i1 < _out.Count; i1++) {
				if (_out [i1].parent.name == "Holodilnik(Clone)") {
					if (_out [i1].parent.GetComponent<Detail_class> ().parameter != -300) {
						if (temp2 == -300) {
							temp2 = 0;
						}
						temp2 += _out [i1].parent.GetComponent<Detail_class> ().parameter;
						count2++;
					} else {
						temp2 = -300;
						break;
					}
				} 
			}
		}
			if (temp2 != -300) {
				List<Transform> _in = GetComponent<Detail_class> ().input;
				for (int i2 = 0; i2 < _in.Count; i2++) {
					if (_in [i2].parent.name == "Nagrevatel(Clone)") {

						if (_in [i2].parent.GetComponent<Detail_class> ().parameter != -300) {
							if (temp1 == -300) {
								temp1 = 0;
							}
							temp1 += _in [i2].parent.GetComponent<Detail_class> ().parameter;
							count1++;
						} else {
							temp1 = -300;
							break;
						}
					} 
				}
			}
			if (temp1 != -300 & temp2 != -300) {
				if (temp1 > temp2) {
					temp1 = temp1 / (count1/1.0f);
					temp2 = temp2 / (count2 / 1.0f);

					this.transform.GetChild (3).GetComponent<Text> ().text = (Mathf.Round (Mathf.Abs (1 - (temp2 + 273) / (temp1 + 273)) * 1000) / 10.0f).ToString () + " %";
					this.GetComponent<Detail_class> ().parameter = Mathf.Round (Mathf.Abs (1 - (temp2 + 273) / (temp1 + 273)) * 1000) / 10.0f;
				} else {
					this.transform.GetChild (3).GetComponent<Text> ().text = "???";
					this.GetComponent<Detail_class> ().parameter = -300;
				}
			} else {
				this.GetComponent<Detail_class> ().parameter = -300;
				this.transform.GetChild (3).GetComponent<Text> ().text = "";
			}
	}
}
