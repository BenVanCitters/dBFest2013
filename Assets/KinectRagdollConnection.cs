using UnityEngine;
using System.Collections;

//this class manages whether the model is controlled by a ragdoll or a
//kinect skeleton.
public class KinectRagdollConnection : MonoBehaviour {
	public Rigidbody ragdollBase;
	public KinectModelControllerV2 kinectSkeleton;
	public int KinectSkeletonIndex = 0;
	
//	[HideInInspector]
	public bool isTrackingKinect;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		isTrackingKinect = (kinectSkeleton.sw.players[KinectSkeletonIndex] 
			                  == Kinect.NuiSkeletonTrackingState.SkeletonTracked);		
	}
}
