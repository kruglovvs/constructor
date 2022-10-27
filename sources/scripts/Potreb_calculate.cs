using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potreb_calculate: MonoBehaviour {
	private float working;

	public void check_potreb () { 
		working = -300;
		if (GetComponent<Detail_class> ().input.Count != 0) {
			List<Transform> _in = GetComponent<Detail_class> ().input;
			for (int i2 = 0; i2 < _in.Count; i2++) {
				if (_in [i2].parent.name == "Workbody(Clone)") {
					if (_in [i2].parent.GetComponent<Workbody_calculate> ().working != -300 & _in [i2].parent.GetComponent<Detail_class> ().parameter != -300) {
						if (working == -300) {
							working = 0;
						}
						working += _in [i2].parent.GetComponent<Workbody_calculate> ().working/(_in [i2].parent.GetComponent<Workbody_calculate> ().out_potrebitel*1.0f);
					} else {

						working = -300;
						this.transform.GetChild (3).GetComponent<Text> ().text = "";
						break;
					}
				}
			}
		}
			if (working != -300) {
				this.transform.GetChild (3).GetComponent<Text> ().text = working.ToString () + " Дж/с";
				this.GetComponent<Detail_class> ().parameter = working;
			} else {
				this.transform.GetChild (3).GetComponent<Text> ().text =  "";
				this.GetComponent<Detail_class> ().parameter = -300;
			}
	}
							

}
