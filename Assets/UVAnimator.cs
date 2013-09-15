using UnityEngine;
using System.Collections;

public class UVAnimator : MonoBehaviour {
	public Vector2 TextureMotion = new Vector2(0.5f,0.5f);
	public Vector2 BumpMotion = new Vector2(0.2f,-0.2f);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 texDelta = Time.deltaTime * TextureMotion;
		Vector2 bmpDelta = Time.deltaTime * BumpMotion;
		Vector2 bOffset = renderer.material.GetTextureOffset("_BumpMap");
		Vector2 toffset = renderer.material.GetTextureOffset("_MainTex");
		toffset = new Vector2((toffset.x + texDelta.x )%1.0f,
			                 (toffset.y + texDelta.y )%1.0f);
		bOffset = new Vector2((bOffset.x + bmpDelta.x )%1.0f,
			                 (bOffset.y + bmpDelta.y )%1.0f);
		renderer.material.SetTextureOffset("_MainTex", toffset);
		renderer.material.SetTextureOffset("_BumpMap", bOffset);
	}
}
