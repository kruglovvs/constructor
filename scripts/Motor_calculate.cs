using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor_calculate : MonoBehaviour {
	public float power_x_UTS;
	private int out_nagrevatel;

	public void check_motor () {
		power_x_UTS = 0;
		out_nagrevatel = 0;
		if (GetComponent<Detail_class> ().input.Count != 0 & GetComponent<Detail_class> ().parameter != -300) {
			List<Transform> _out = GetComponent<Detail_class> ().output;
			for (int i3 = 0; i3 < _out.Count; i3++) {
				if (_out [i3].parent.name == "Nagrevatel(Clone)") {
					out_nagrevatel++;
				}
			}
			if (out_nagrevatel != 0) {
				List<Transform> _in = GetComponent<Detail_class> ().input;
				for (int i2 = 0; i2 < _in.Count; i2++) {
					if (_in [i2].parent.name == "Istochnik(Clone)") {
						if (_in [i2].parent.GetComponent<Detail_class> ().parameter != -300) {
							power_x_UTS += GetComponent<Detail_class> ().parameter * _in [i2].parent.GetComponent<Detail_class> ().parameter / (out_nagrevatel * 1.0f);
						} else {
							power_x_UTS = -300;
							break;
						}
					}
				}
			} else {
				power_x_UTS = -300;
			}
		} else {
			power_x_UTS = -300;
		}
	}
}
