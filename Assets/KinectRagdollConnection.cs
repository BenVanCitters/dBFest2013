using UnityEngine;
using System.Collections;

//this class manages whether the model is controlled by a ragdoll or a
//kinect skeleton.
public class KinectRagdollConnection : MonoBehaviour {
	public ParticleSystem LeftHandParticles;
	public ParticleSystem RightHandParticles;
	public Rigidbody ragdollBase;
	public KinectModelControllerTorso kinectSkeleton;
	//public int KinectSkeletonIndex = 0;
	
	[HideInInspector]
	public bool isTrackingKinect = false;
	// Use this for initialization
	void Start () {
		kinectSkeleton.enabled = isTrackingKinect;
		setTracking(isTrackingKinect);
	}
	
	// Update is called once per frame
	void Update () {
		kinectSkeleton.sw.pollSkeleton();
		Debug.Log("kinectSkeleton.sw.trackedPlayers[KinectSkeletonIndex]: " +  kinectSkeleton.sw.trackedPlayers[kinectSkeleton.player]);
		bool isNextFrameTracked= (kinectSkeleton.sw.trackedPlayers[kinectSkeleton.player] >= 0);
		if(isTrackingKinect != isNextFrameTracked)	
		{
			setTracking(isTrackingKinect);
		}
	}
	
	
	void setTracking(bool tracking)
	{
		isTrackingKinect = tracking;
			
		kinectSkeleton.enabled = isTrackingKinect;
		LeftHandParticles.gameObject.SetActive( isTrackingKinect);
		RightHandParticles.gameObject.SetActive( isTrackingKinect);
//			RightHandParticles.enableEmission = isTrackingKinect;
		foreach (Transform child in ragdollBase.transform)
		{
			recusivelySetRagDollEnabled(child.gameObject,isTrackingKinect);
		}
	}
	
	void recusivelySetRagDollEnabled(GameObject go, bool isKinematic)
	{
		Rigidbody rb = (Rigidbody)go.GetComponent<Rigidbody>();
		if(rb!= null)
		{
			rb.isKinematic = isKinematic;
		}
		foreach (Transform child in go.transform)
		{
			recusivelySetRagDollEnabled(child.gameObject,isKinematic);
		}
	}
}
