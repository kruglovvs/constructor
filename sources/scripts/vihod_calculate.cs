using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vihod_calculate : MonoBehaviour {
	public float vihod;

	public void check_vihod () {
		vihod = -300;
		if (GetComponent<Detail_class> ().input.Count != 0) {
			List<Transform> _in = GetComponent<Detail_class> ().input;
			for (int i2 = 0; i2 < _in.Count; i2++) {
				if (_in [i2].parent.name == "Holodilnik(Clone)") {
					if (_in [i2].parent.GetComponent<Holodilnik_calculate> ().holod != -300 & _in [i2].parent.GetComponent<Detail_class> ().parameter != -300) {
						if (vihod == -300) {
							vihod = 0;
						}
						vihod += _in [i2].parent.GetComponent<Holodilnik_calculate> ().holod;
					} else {
						vihod = -300;
						this.transform.GetChild (3).GetComponent<Text> ().text = "";
						break;
					}
				}
			}
		}
			if (vihod != -300) {
				this.transform.GetChild (3).GetComponent<Text> ().text = vihod.ToString () + " Дж/с";
				this.GetComponent<Detail_class> ().parameter = vihod;
			} else {
				this.transform.GetChild (3).GetComponent<Text> ().text =  "";
				this.GetComponent<Detail_class> ().parameter = -300;
			}
		}
}
