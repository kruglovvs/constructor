using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using ExcelLibrary.SpreadSheet;
using Ookii;
using SFB;

public class Load : MonoBehaviour {
	public Transform details_examples;
	private Transform pole;
	public GameObject details_objects_null;
	public GameObject monitor;
	private GameObject start_menu;
	public GameObject error;
	public GameObject drawing_systems;
	public GameObject drawing;
	private string path;
	private string detail_parameter;

	public void Start(){
		start_menu = GameObject.Find ("/Start_Menu");
		pole = GameObject.Find ("/Pole").transform;
	}

	public void load(){
		error.SetActive(false);
		// удаляем списки деталей и линий
		for (int i = 0; i < pole.childCount; i++){
			Destroy(pole.GetChild(i).gameObject);	
		}
		//создаём список линий и деталей
		GameObject drawing_system = Instantiate(drawing_systems, pole) as GameObject;
		GameObject details_objects = Instantiate (details_objects_null, Vector3.zero, Quaternion.identity, pole) as GameObject;
		//открываем проводник
		try{
			path = StandaloneFileBrowser.OpenFilePanel ("Выберите сохранение",Application.dataPath,"xls", false)[0];
		} catch {
		}
		if (path!=null) {
			if(path.Length!=0) {
				if (path.Substring (path.Length - 4, 4) == ".xls") {
					//создаём книгу и лист
					Camera.main.transform.position = Vector3.zero;
					Workbook book = Workbook.Load (path);
					Worksheet sheet = book.Worksheets [0];
					//создаём детали. По количеству из первой клетки
					for (int i1 = 1; i1 < int.Parse (sheet.Cells [0, 0].ToString ()) + 1; i1++) {
						//сравниваем с списком details_examples
						for (int i2 = 0; i2 < details_examples.transform.childCount; i2++) {
							if (sheet.Cells [i1, 0].ToString () == details_examples.transform.GetChild (i2).name) {
								//создаём деталь и присваиваем ей параметр и текст параметра
								GameObject clone_detail = Instantiate (details_examples.GetChild (i2).gameObject, new Vector3 (int.Parse (sheet.Cells [i1, 1].ToString ()), int.Parse (sheet.Cells [i1, 2].ToString ()), 100), Quaternion.identity, details_objects.transform) as GameObject;
								clone_detail.GetComponent<Detail_class> ().parameter = float.Parse (sheet.Cells [i1, 3].ToString ());
								if (sheet.Cells [i1, 3].ToString () != "-300") {
								switch (clone_detail.name){
									case "Motor(Clone)":
									detail_parameter = " кг/с";
									break;
									case "Workbody(Clone)":
									detail_parameter = " %";
									break;
									case "Istochnik(Clone)":
									detail_parameter = " Дж/кг";
									break;
									case "Potrebitel(Clone)":
									detail_parameter = " Дж/c";
									break;
									default:
									detail_parameter = " C";
									break;
								}
									clone_detail.transform.GetChild (3).GetComponent<Text> ().text = sheet.Cells [i1, 3].ToString () + detail_parameter;
								}
								break;
							}
						}
					}
					//рисуем линии
					for (int i1 = 1; i1 < int.Parse (sheet.Cells [0, 0].ToString ()) + 1; i1++) {
						for (int i2 = 4; sheet.Cells [i1, i2].ToString () != ""; i2++) {
							GetComponent<Make_line> ().make_line(details_objects.transform.GetChild (i1 - 1).GetChild (0), details_objects.transform.GetChild (int.Parse (sheet.Cells [i1, i2].ToString ())).GetChild (1),drawing,drawing_system.transform);
						}
					}		
					monitor.SetActive (true);
					start_menu.SetActive (false);
					pole.gameObject.SetActive (true);	
					pole.GetComponent<Retranslater> ().retranslate();
					} else {
						error.SetActive(true);
					}
			}
		}
		path = "";
	}
}
