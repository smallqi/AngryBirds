using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void LateUpdate()
	{
		if(Bird.isPlay){
			this.transform.Translate (Vector3.right*Time.deltaTime*Bird.f_moveSpeed,Space.World);
		}
	}
}
