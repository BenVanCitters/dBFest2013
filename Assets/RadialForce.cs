using UnityEngine;
using System.Collections;

public class RadialForce : MonoBehaviour {
	
	public GameObject forceCenter = null;
	public float Magnitude = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		recusivelyUpdateRBs(this.gameObject);
	}
	
	void recusivelyUpdateRBs(GameObject go)
	{
		Rigidbody rb = (Rigidbody)go.GetComponent<Rigidbody>();
		if(rb!= null)
		{
			Vector3 dir = go.transform.position-forceCenter.transform.position;
			dir.Normalize();
			dir.x = 0;
			rb.AddForce(dir*Magnitude);
		}
		foreach (Transform child in go.transform)
		{
			recusivelyUpdateRBs(child.gameObject);
		}
	}
}
