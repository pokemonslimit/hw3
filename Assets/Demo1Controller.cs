using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using TouchScript.Hit;
using DG.Tweening;

public class Demo1Controller : MonoBehaviour {

	// Use this for initialization
	public TapGesture singleTap;
	public TapGesture doubleTap;
	public Animator animator;

	public Rigidbody Model;

	// Use this for initialization
	void Start () {
		animator.SetBool ("idle", true);
		//animator = this.GetComponent<Animator> ();

		singleTap.Tapped += (object sender, System.EventArgs e) => 
		{
			TouchHit hit;
			singleTap.GetTargetHitResult(out hit);
			Vector3 targetPoint = hit.Point;
			animator.SetTrigger("Single");
			Debug.Log("Single");
		};

		doubleTap.Tapped += (object sender, System.EventArgs e) => 
		{
			TouchHit hit;
			doubleTap.GetTargetHitResult(out hit);

			Vector3 targetPoint = hit.Point;
			animator.SetTrigger("Double");
			Debug.Log("Double");
		};
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.acceleration.y >= 0.1) {
			animator.SetTrigger ("Shake");
			Debug.Log ("Shake");
		}

		if (Input.GetKey (KeyCode.W)) {
			animator.SetTrigger("Single");
			Debug.Log("Single");
		}
		
	}
}
