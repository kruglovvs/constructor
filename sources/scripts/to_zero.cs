using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class to_zero : MonoBehaviour {
	public void zero () {
		Camera.main.transform.position = new Vector3 (0,0,-200);
	}
}
