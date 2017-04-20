using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snappoint : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Snap Point") {
			GetComponentInParent<part> ().snaps.Remove(this.transform);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Snap Point") {
			GetComponentInParent<part> ().snaps.Add(this.transform);
		}
	}
}
