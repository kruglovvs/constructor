using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera_position_x : MonoBehaviour {
	private Transform Camera_transform;
	void Start(){
		Camera_transform = Camera.main.transform;//GameObject.Find ("/Main Camera").transform;
	}
	void Update () {
		this.gameObject.GetComponent<Text> ().text = Mathf.Floor(Camera_transform.position.x).ToString();
	}
}
