using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snap : MonoBehaviour {

	public float pickUpRange;
	public GameObject MotherBoard;

	private part MotherBoardPart;

	private GameObject picked;
	private part pickedPart;

	void Start () {
		MotherBoardPart = MotherBoard.GetComponent<part> ();
	}

	void Update() {
		RaycastHit hit;

		if (Input.GetMouseButtonUp (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); 
			if (Physics.Raycast (ray, out hit, float.MaxValue) && hit.collider.gameObject.tag.Equals ("Part")) {
				GameObject hitGO = hit.collider.gameObject;

				if (picked == null) {
					picked = hit.collider.gameObject;
					pickedPart = picked.GetComponent<part> ();

					pickedPart.toglePicked ();
				} else if (picked != null && picked != hitGO) {
					part hitPart = hitGO.GetComponent<part> ();

					if (hitPart.canIndex () /*&& hitPart.type != pickedPart.type*/) {
						Vector3 newPos = hitGO.transform.position + pickedPart.getFirstsnapOffset () - hitPart.getsnapOffset ();

						picked.transform.position = newPos;
						pickedPart.toglePicked ();

						if (picked.name != "MotherBoard") {
							picked.transform.SetParent (hitGO.transform);
						}

						picked = null;
						pickedPart = null;



					} else {
						pickedPart.setErrorMaterial ();
					}
				} else {
					pickedPart.toglePicked();

					picked = null;
					pickedPart = null;
				}
			}
		}

		if (!MotherBoardPart.canIndex()) {
			Timer tr = GetComponent<Timer> ();
			tr.GOLabel.text = "You Win";
			tr.GOLabel.enabled = true;
			tr.enabled = false;
		}
	}
}
