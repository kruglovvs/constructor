using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nagrevatel_calculate : MonoBehaviour {
	public float powers;
	private int out_workbody;

	public void check_nagrevatel () {
		powers = 0;
		out_workbody = 0;
		if (GetComponent<Detail_class> ().input.Count != 0 & GetComponent<Detail_class> ().parameter != -300) {
			List<Transform> _out = GetComponent<Detail_class> ().output;
			for (int i3 = 0; i3 < _out.Count; i3++) {
				if (_out [i3].parent.name == "Workbody(Clone)") {
					out_workbody++;
				}
			}
			if (out_workbody != 0) {
				List<Transform> _in = GetComponent<Detail_class> ().input;
				for (int i2 = 0; i2 < _in.Count; i2++) {
					if (_in [i2].parent.name == "Motor(Clone)") {
						
						if (_in [i2].parent.GetComponent<Motor_calculate> ().power_x_UTS != -300 & _in [i2].parent.GetComponent<Detail_class> ().parameter != -300) {
							powers += _in [i2].parent.GetComponent<Motor_calculate> ().power_x_UTS / (out_workbody * 1.0f);
						} else {
							powers = -300;
							break;
						}
					}
				}
			} else {
				powers = -300;
			}
		} else { 
			powers = -300;
		}
	}
}
