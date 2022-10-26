using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lines_controller: MonoBehaviour {
	private RaycastHit2D hit;
	private Transform bochina1;
	private Transform bochina2;
	private LineRenderer linerenderer;
	public GameObject drawing;
	private GameObject pole;
	public Sprite bochina_green;
	public Sprite bochina_black;

	public void Start(){
		pole = GameObject.Find ("/Pole");
	}

	public void Update(){
		if (Input.GetMouseButtonDown (0)) {
			//создаём луч из камеры на поле
			hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, -200)), new Vector3 (0, 0, 200));
			if (hit.transform == null) {
				//если луч не попадает на коллайдеры, то проверяем, нажали ли на линию
				BroadcastMessage ("klick", Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0)), SendMessageOptions.DontRequireReceiver);
			}
			if (hit.transform != null) {
				if (hit.transform.tag == "Bochina") {
					//если нажали на ножку
					if (bochina1 == null) {
						//запоминаем ножку и делаем её зелёной
						bochina1 = hit.transform;
						bochina1.GetComponent<Image> ().sprite= bochina_green;
					} else {			
						//проверяем, что соблюдена полярность
						if (bochina1 != hit.transform & bochina1.parent != hit.transform.parent & hit.transform.GetSiblingIndex() != bochina1.GetSiblingIndex()) {
							//запоминаем вторую ножку
							bochina2 = hit.transform;
							bool key = true;
							//проверяем, что они уже не соединены
							if (bochina1.GetSiblingIndex()==0){
								for (int i = 0; i < bochina1.parent.GetComponent<Detail_class> ().input.Count; i++) {
									if (bochina1.parent.GetComponent<Detail_class> ().input [i] == bochina2) {
										key = false;
										break;
									}
								}
								if (key) {
									Transform drawing_systems = GameObject.Find ("Drawing_systems(Clone)").transform;
									GetComponent<Make_line> ().make_line (bochina1, bochina2, drawing, drawing_systems);
								}
							} else { 
								for (int i = 0; i < bochina1.parent.GetComponent<Detail_class> ().output.Count; i++) {
									if (bochina1.parent.GetComponent<Detail_class> ().output [i] == bochina2) {
										key = false;
										break;
									}
								}
								if (key) {	
									Transform drawing_systems = GameObject.Find ("Drawing_systems(Clone)").transform;
									GetComponent<Make_line> ().make_line (bochina2, bochina1, drawing, drawing_systems);
								}
							}
							//обновляем вычисления и делаем ножку чёрной, очищаем память
							pole.GetComponent<Retranslater> ().retranslate ();
							bochina1.GetComponent<Image> ().sprite = bochina_black;
							bochina2 = null;
							bochina1 = null;
						} else {
	//очищаем память и делаем ножку чёрной
							if (bochina1 != null) {
								bochina1.GetComponent<Image> ().sprite = bochina_black;
							}
							bochina2 = null;
							bochina1 = null;
						}
					}
				} else {
					if (bochina1 != null) {
						bochina1.GetComponent<Image> ().sprite = bochina_black;
					}
					bochina2 = null;
					bochina1 = null;
				}
			} else {
				if (bochina1 != null) {
					bochina1.GetComponent<Image> ().sprite = bochina_black;
				}
				bochina2 = null;
				bochina1 = null;
			}
		}
	}
}
