using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Make_line : MonoBehaviour {
	public void make_line (Transform transform1, Transform transform2, GameObject drawing, Transform drawing_systems){
		GameObject _drawing = Instantiate (drawing, drawing_systems);
		_drawing.GetComponent<Draw_line> ().transform1 = transform1;
		_drawing.GetComponent<Draw_line> ().transform2 = transform2;
		transform1.parent.GetComponent<Detail_class> ().input.Add (transform2);
		transform2.parent.GetComponent<Detail_class>().output.Add (transform1);
		transform1.parent.GetComponent<Detail_class> ().lines.Add (_drawing);
		transform2.parent.GetComponent<Detail_class> ().lines.Add (_drawing);
		//параметры линии и отрисовываем
		_drawing.GetComponent<Draw_line> ().linerenderer = _drawing.GetComponent<LineRenderer> ();
		_drawing.GetComponent<Draw_line> ().draw_line ();
	}
}
