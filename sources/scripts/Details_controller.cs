using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Details_controller : MonoBehaviour {
	private RaycastHit2D hit;
	public GameObject delete;
	private GameObject event_system;
	public GameObject details_menu;
	public GameObject details_list	;
	public GameObject change_buttom ;
	private string detail_parameter;
	public InputField inputfield;
	private GameObject last_detail;

	public void Start(){
		event_system = GameObject.Find ("/EventSystem");
	}

	private void Update(){	
		if (Input.GetMouseButtonDown (0)) {
			//пускаем луч на игровое поле
			hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 200)), new Vector3 (0, 0, -200));
			if (hit.transform != null) {
				//если он попал на деталь
				if (hit.transform.tag == "Detail") {
					//закрываем лишние кнопки
					Debug.Log(hit.transform.GetSiblingIndex());
					details_list.SetActive (false);
					details_menu.SetActive (false);
					delete.SetActive (true);
					//запоминаем, на кого попали
					last_detail = hit.transform.gameObject;
					switch (last_detail.name) {
						case "Motor(Clone)":
							detail_parameter = "Перекачка в кг/c";
						change_buttom.SetActive (true);
							break;
						case "Istochnik(Clone)":
							detail_parameter = "Удельная теплота сгорания в Дж/кг";
						change_buttom.SetActive (true);
							break;
					case "Holodilnik(Clone)":
							detail_parameter = "Температура в Цельсиях";
						change_buttom.SetActive (true);

							break;
					case "Nagrevatel(Clone)":
						detail_parameter = "Температура в Цельсиях";
						change_buttom.SetActive (true);

						break;
						}
						inputfield.placeholder.GetComponent<Text>().text = detail_parameter;
					
				} else {
					if (hit.transform.name == "Delete") {
						event_system.GetComponent<Destroy_detail> ().last_detail = last_detail;
						delete.SetActive (false);
						change_buttom.SetActive (false);
					} else {
						event_system.GetComponent<Destroy_detail> ().last_detail = null;
						delete.SetActive (false);
					}
					if (hit.transform.name == "Change_parameter") {
						//event_system.GetComponent<Get_temp> ().key = true;
						event_system.GetComponent<Get_temp> ().last_detail = last_detail;
						delete.SetActive (false);
						this.gameObject.SetActive (false);
						change_buttom.SetActive (false);
						inputfield.gameObject.SetActive (true);
						inputfield.Select ();
					} else {
						event_system.GetComponent<Get_temp> ().last_detail = null;
						change_buttom.SetActive (false);
					}
				}
			} else {
				details_list.SetActive (false);
				details_menu.SetActive (false);
				event_system.GetComponent<Destroy_detail> ().last_detail = null;
				event_system.GetComponent<Get_temp> ().last_detail = null;
				delete.SetActive (false);
				change_buttom.SetActive (false);

			}
			GetComponent<Retranslater> ().retranslate ();
		}

		if (Input.GetMouseButton (0) & hit.collider != null ) {
			if((hit.transform.tag=="Detail") /*& (hit.transform.position != new Vector3 (Mathf.Floor (Camera.main.ScreenToWorldPoint(Input.mousePosition).x / 20) * 20, Mathf.Floor (Camera.main.ScreenToWorldPoint(Input.mousePosition).y / 20) * 20, -10))*/){
				hit.transform.position = new Vector3(Mathf.Floor (Camera.main.ScreenToWorldPoint(Input.mousePosition).x / 20) * 20, Mathf.Floor (Camera.main.ScreenToWorldPoint(Input.mousePosition).y / 20) * 20, 100);
				BroadcastMessage ("draw_line",SendMessageOptions.DontRequireReceiver);
			}
		}
		if (Input.GetMouseButtonUp(0)){	
				hit = Physics2D.Raycast(new Vector3(0,0,10230), new Vector3(0,0,10230));	
		}
	}
}
