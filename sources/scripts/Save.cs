using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.IO;
using ExcelLibrary.SpreadSheet;
using SFB;
//using UnityEngine.UI;

public class Save : MonoBehaviour {
	private Transform Details_objects;

	public void save(){
		//открываем проводник
		string path = StandaloneFileBrowser.SaveFilePanel ("Сохраните схему",Application.dataPath,"Схема_","xls" );
		if (path != null) {
			if (path.Length != 0) {
				//ищем место, где находятся детали
				Details_objects = GameObject.Find ("Details_objects(Clone)").transform;
				//создаём книгу и лист
				Workbook workbook = new Workbook ();
				Worksheet worksheet = new Worksheet ("Первый лист");
				for (int i1 = 1; i1 < Details_objects.childCount + 1; i1++) {
					//сохраняем параметры каждой детали
					worksheet.Cells [i1, 0] = new Cell (Details_objects.GetChild (i1 - 1).name.Substring (0, Details_objects.GetChild (i1 - 1).name.Length - 7));
					worksheet.Cells [i1, 1] = new Cell (Mathf.Round (Details_objects.GetChild (i1 - 1).position.x).ToString ());
					worksheet.Cells [i1, 2] = new Cell (Mathf.Round (Details_objects.GetChild (i1 - 1).position.y).ToString ());
					worksheet.Cells [i1, 3] = new Cell (Details_objects.GetChild (i1 - 1).GetComponent<Detail_class> ().parameter.ToString ());
					for (int i2 = 4; i2 < Details_objects.GetChild (i1 - 1).GetComponent<Detail_class> ().input.Count + 4; i2++) {
						worksheet.Cells [i1, i2] = new Cell (Details_objects.GetChild (i1 - 1).GetComponent<Detail_class> ().input [i2 - 4].parent.GetSiblingIndex ().ToString ());
					}
				}
				//заносим количество деталей
				worksheet.Cells [0, 0] = new Cell (Details_objects.childCount.ToString ());
				//добавляем лист в книгу
				workbook.Worksheets.Add (worksheet);
				//сохраняем книгу
				workbook.Save (path);
			}
		}
		path="";
	} 
}
