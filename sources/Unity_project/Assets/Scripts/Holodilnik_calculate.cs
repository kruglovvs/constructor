using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holodilnik_calculate : MonoBehaviour {
	public float holod;
	private int out_vihod;

	public void check_holodilnik () {
		holod = 0;
		out_vihod = 0;
		if (GetComponent<Detail_class> ().input.Count != 0 & GetComponent<Detail_class> ().parameter != -300) {
			List<Transform> _out = GetComponent<Detail_class> ().output;
			for (int i3 = 0; i3 < _out.Count; i3++) {
				if (_out [i3].parent.name == "Vihod(Clone)") {
					out_vihod++;
				}
			}
			if (out_vihod != 0) {
				List<Transform> _in = GetComponent<Detail_class> ().input;
				for (int i2 = 0; i2 < _in.Count; i2++) {
					if (_in [i2].parent.name == "Workbody(Clone)") {
						if (_in [i2].parent.GetComponent<Workbody_calculate> ().working != -300 & _in [i2].parent.GetComponent<Detail_class> ().parameter != -300) {
							holod += _in [i2].parent.GetComponent<Workbody_calculate> ().working / _in [i2].parent.GetComponent<Detail_class> ().parameter * 1.0f * (100.0f - _in [i2].parent.GetComponent<Detail_class> ().parameter) / _in [i2].parent.GetComponent<Workbody_calculate> ().out_holodilnik / out_vihod;
						} else {
							holod = -300;
							break;
						}
					}
				}
			} else {
				holod = -300;
			}
		} else {
			holod = -300;
		}
	}

}
