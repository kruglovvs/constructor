using UnityEngine;
using System.Collections;
using System.Linq;
using System.Text;
using System;

public class Camera_controller : MonoBehaviour {
	private float speed = 150.0f;
	private Vector3 mousePosition;

	public void Update() {
		//перемещение клавишами
		Vector2 movement = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);
		//увеличиваем модуль перемещения до speed 
		movement = Vector2.ClampMagnitude(movement, speed) * Time.deltaTime;
		//перемещаем камеру
		Camera.main.GetComponent<CharacterController>().Move(movement);
		//перемещение мышью
		mousePosition.x = Mathf.Clamp (Input.mousePosition.x,0,Screen.width);
		mousePosition.y = Mathf.Clamp (Input.mousePosition.y,0,Screen.height);
		if ((mousePosition.x >= Screen.width - 3) | (mousePosition.x <= 3)|(mousePosition.y <= 3)|(mousePosition.y >= Screen.height-3)) { 
			Camera.main.transform.position += new Vector3 ((mousePosition.x - Screen.width/2)/(Screen.width/2)*200*Time.deltaTime,(mousePosition.y-Screen.height/2)/(Screen.height/2)*200*Time.deltaTime,0);
		}
	}
}