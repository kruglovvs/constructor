using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Zoom : MonoBehaviour {
	private float mousewheel;

	public void Start(){
		Camera.main.orthographicSize = 190;
		switch (Screen.width) {
		case 800:
			Camera.main.orthographicSize = 245;
			break;
		case 640:
			Camera.main.orthographicSize = 235;
			break;
		}
	}

	public void Update(){
		mousewheel = Input.GetAxis ("Mouse ScrollWheel");
		if (mousewheel > 0.1&Camera.main.orthographicSize>110) {
			Camera.main.orthographicSize -= Time.deltaTime * 250;
			Mathf.Clamp (Camera.main.orthographicSize, 110, 500);
		} else {
			if (mousewheel < -0.1&Camera.main.orthographicSize<500) {
				Camera.main.orthographicSize += Time.deltaTime * 250;
				Mathf.Clamp (Camera.main.orthographicSize, 110, 500);
			}
		}
	}
}
