using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workbody_calculate : MonoBehaviour {

	public float working;
	public int out_holodilnik;
	public int out_potrebitel;

	public void check_workbody () {
		working = 0;
		out_holodilnik=0;
		out_potrebitel = 0;
		if (GetComponent<Detail_class> ().input.Count != 0 & GetComponent<Detail_class> ().parameter != -300) {
			List<Transform> _out = GetComponent<Detail_class> ().output;
			for (int i3 = 0; i3 < _out.Count; i3++) {
				switch (_out [i3].parent.name) {
				case "Potrebitel(Clone)":
					out_potrebitel++;
					break;
				case "Holodilnik(Clone)":
					out_holodilnik++;
					break;
				}
			}
			if (out_potrebitel != 0 & out_holodilnik != 0) {
				List<Transform> _in = GetComponent<Detail_class> ().input;
				for (int i2 = 0; i2 < _in.Count; i2++) {
					if (_in [i2].parent.name == "Nagrevatel(Clone)") {
						if (_in [i2].parent.GetComponent<Nagrevatel_calculate> ().powers != -300 & _in [i2].parent.GetComponent<Detail_class> ().parameter != -300) {
							working += _in [i2].parent.GetComponent<Nagrevatel_calculate> ().powers * GetComponent<Detail_class> ().parameter / 100.0f;
						} else {
							working = -300;
							break;
						}
					}
				}
			} else {
				working = -300;
			}
		} else {
			working = -300;
		}
	}
}
