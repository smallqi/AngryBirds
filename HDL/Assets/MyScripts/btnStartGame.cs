using UnityEngine;
using System.Collections;

public class btnStartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnClick () {
		Application.LoadLevel("Level01");
		Bird.isPlay=true;
	}
}
