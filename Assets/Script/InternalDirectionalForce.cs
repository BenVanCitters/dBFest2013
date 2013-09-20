using UnityEngine;
using System.Collections;

public class InternalDirectionalForce : MonoBehaviour {
	private Rigidbody myRigidBody;
	public Vector3 appliedForce = new Vector3(0,-1,0);
	// Use this for initialization
	void Start () {
		float magnitude = appliedForce.magnitude;
		appliedForce = this.transform.localToWorldMatrix.MultiplyVector(appliedForce);
		appliedForce.Normalize();
		appliedForce *= magnitude;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerStay(Collider other)
	{
		other.attachedRigidbody.AddForce(appliedForce);
//		Debug.Log("collider.attachedRigidbody: ");
		
	}
}
