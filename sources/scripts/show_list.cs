using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show_list : MonoBehaviour {
	public void details_list_change_enabled(GameObject details_list){
		details_list.SetActive (!(details_list.activeInHierarchy));
	}
}
