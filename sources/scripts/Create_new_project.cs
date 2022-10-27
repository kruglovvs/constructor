using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_new_project : MonoBehaviour {
	private Transform Pole;
	public GameObject Details_objects_null;
	public GameObject Drawing_systems;

	public void Start(){
		Pole = GameObject.Find("/Pole").transform;
	}

	public void new_game (){
		GameObject.Find ("/Main Camera").transform.position = Vector3.zero;
		for (int i = 0; i < Pole.childCount; i++){
			Destroy(Pole.GetChild(i).gameObject);	
		}
		GameObject Drawing_syste = Instantiate(Drawing_systems, Pole) as GameObject;
		GameObject Details_objects = Instantiate (Details_objects_null, Pole) as GameObject;
	
	}
}
