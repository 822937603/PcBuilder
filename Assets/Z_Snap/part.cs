using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class part : MonoBehaviour {

	public string type;
	public int powerUsage;

	public List<Transform> snaps;

	private Transform firstSnap;
	private bool picked = false;
	private Vector3 startPosition;

	private Renderer r;

	// Use this for initialization
	void Start () {
		snaps = new List<Transform> ();
		snappoint[] snap = GetComponentsInChildren<snappoint> ();
		foreach (snappoint s in snap) {
			snaps.Add (s.transform);
		}
		firstSnap = snaps [0];
		r = GetComponent<Renderer> ();
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Vector3 getsnapOffset(){
		return this.transform.position - snaps[0].position;
	}

	public Vector3 getFirstsnapOffset(){
		return this.transform.position - firstSnap.position;
	}

	public bool canIndex(){
		if (snaps.Count > 0) {
			return true;
		} else {
			return false;
		}
	}

	public void toglePicked(){
		if (picked) {
			picked = false;
			//r.material = normalMaterial;
		} else {
			picked = true;
			//r.material = pickedMaterial;
		}
	}

	public void setErrorMaterial(){
		picked = true;
		//r.material = errorMaterial;
	}
}
