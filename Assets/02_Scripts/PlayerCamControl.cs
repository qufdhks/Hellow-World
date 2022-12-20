using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamControl : MonoBehaviour {
	private GameObject JKC;//Junkochan

	// Use this for initialization
	void Start () {
		JKC = GameObject.Find("Player1");//Find the character object
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.transform.rotation = Quaternion.Lerp(this.transform.rotation,Quaternion.LookRotation(JKC.transform.position - this.transform.position + Vector3.up*0.4f, Vector3.up),0.2f);//Look at Junkochan

	}
}
