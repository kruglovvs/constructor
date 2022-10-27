using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retranslater : MonoBehaviour {
	public void retranslate(){
		BroadcastMessage ("check",SendMessageOptions.DontRequireReceiver);
		BroadcastMessage ("check_motor",SendMessageOptions.DontRequireReceiver);
		BroadcastMessage ("check_nagrevatel",SendMessageOptions.DontRequireReceiver);
		BroadcastMessage ("check_workbody",SendMessageOptions.DontRequireReceiver);
		BroadcastMessage ("check_potreb",SendMessageOptions.DontRequireReceiver);
		BroadcastMessage ("check_holodilnik",SendMessageOptions.DontRequireReceiver);
		BroadcastMessage ("check_vihod",SendMessageOptions.DontRequireReceiver);
	}
}
