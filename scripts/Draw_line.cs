using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw_line : MonoBehaviour {
	public Transform transform1;
	public Transform transform2;
	public LineRenderer linerenderer;
	private GameObject Pole;
 
	public void Start(){
		//устанавливаем параметры линий и ищем игровое поле
		Pole = GameObject.Find ("Pole");
	}
		
	public void klick (Vector3 pos){
		//для каждого фрагмента линии
		for (int i = 0; i < 3; i++) {
			//если координаты мыши во время клика совпадают с координатами линии +- диапоноз
			if ((((pos.x >= linerenderer.GetPosition (i).x - 20) & (pos.x <= linerenderer.GetPosition (i + 1).x + 20)) | ((pos.x <= linerenderer.GetPosition (i).x - 20) & (pos.x >= linerenderer.GetPosition (i + 1).x + 20))) & (((pos.y <= linerenderer.GetPosition (i).y - 20) & (pos.y >= linerenderer.GetPosition (i + 1).y + 20)) | ((pos.y >= linerenderer.GetPosition (i).y - 20) & (pos.y <= linerenderer.GetPosition (i + 1).y + 20)))) {
				//для обоих соединённых деталей ищем в списке входа/выхода соединённую деталь и удаляем её из списка
				for (int i2 = 0; i2 < transform1.parent.GetComponent<Detail_class> ().input.Count; i2++) {
					if (transform1.parent.GetComponent<Detail_class> ().input [i2] == transform2) {
						transform1.parent.GetComponent<Detail_class> ().input.Remove (transform1.parent.GetComponent<Detail_class> ().input [i2]);
					}
				}
				for (int i3 = 0; i3 < transform2.parent.GetComponent<Detail_class> ().output.Count; i3++) {
					if (transform2.parent.GetComponent<Detail_class> ().output [i3] == transform1) {
						transform2.parent.GetComponent<Detail_class> ().output.Remove (transform2.parent.GetComponent<Detail_class> ().output [i3]);
					}
				}
				//уничтожаем саму линию и перевычисляем КПД и прочее
				DestroyObject (this.gameObject);
				Pole.GetComponent<Retranslater> ().retranslate ();
			}
		}
	}

	public void draw_line () {
		//вычисляем взаимное положение ножек детали и выставляем координаты точек линии
		linerenderer.SetPosition(0, new Vector3(transform1.position.x,transform1.position.y,100));
			if (transform1.position.x>transform2.position.x){
				linerenderer.SetPosition (1, new Vector3 ((transform1.position.x + transform2.position.x) / 2, transform1.position.y, 100));
				linerenderer.SetPosition (2, new Vector3 ((transform1.position.x + transform2.position.x) / 2, transform2.position.y, 100));
			} else {
				if (Mathf.Abs(transform1.position.y - transform2.position.y) / 2 > 30) {
					linerenderer.SetPosition (1, new Vector3 (transform1.position.x, (transform1.position.y + transform2.position.y) / 2, 100));
					linerenderer.SetPosition (2, new Vector3 (transform2.position.x, (transform1.position.y + transform2.position.y) / 2, 100));
				} else {
					if(transform1.position.y-transform2.position.y>=0){
						linerenderer.SetPosition (1, new Vector3 (transform1.position.x,transform1.position.y +70, 100));
						linerenderer.SetPosition (2, new Vector3 (transform2.position.x, transform1.position.y +70, 100));
					} else {
						linerenderer.SetPosition (1, new Vector3 (transform1.position.x, transform1.position.y - 70, 100));
						linerenderer.SetPosition (2, new Vector3 (transform2.position.x, transform1.position.y -70, 100));
					}
				}
			}
		linerenderer.SetPosition (3, new Vector3(transform2.position.x,transform2.position.y,100));
	}
}

