using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Create_detail : MonoBehaviour {
	public InputField get_text;
	private GameObject Event_Sys;
	private GameObject Pole;
	private string detail_parameter;

	public void Start(){
		Pole = GameObject.Find ("/Pole");
		Event_Sys = GameObject.Find ("/EventSystem");
	}
	
	public void create_detail( GameObject _detail){ 
		Transform Details_objects = GameObject.Find ("Details_objects(Clone)").transform;
		GameObject clone_detail = Instantiate (_detail, new Vector3((Mathf.FloorToInt(Camera.main.ViewportToWorldPoint(Camera.main.rect.center).x)/20)*20,(Mathf.FloorToInt(Camera.main.ViewportToWorldPoint(Camera.main.rect.center).y)/20)*20,100) , Quaternion.identity,Details_objects) as GameObject;
		if (clone_detail.name == "Istochnik(Clone)"|clone_detail.name == "Motor(Clone)"|clone_detail.name == "Holodilnik(Clone)"|clone_detail.name == "Nagrevatel(Clone)") {
			switch (clone_detail.name) {
			case "Motor(Clone)":
				detail_parameter = "Перекачка в кг/c";
				break;
			case "Istochnik(Clone)":
				detail_parameter = "Удельная теплота сгорания в Дж/кг";
				break;
			default:
				detail_parameter = "Температура в Цельсиях";
				break;
			}
			get_text.placeholder.GetComponent<Text>().text = detail_parameter;
			get_text.gameObject.SetActive (true);
			get_text.Select ();
			Pole.SetActive (false);
			Event_Sys.GetComponent<Get_temp> ().last_detail = clone_detail;
			Pole.GetComponent<Retranslater> ().retranslate ();
		}
	}
}
