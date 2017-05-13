using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using TouchScript.Hit;
using DG.Tweening;

public class FlickController : MonoBehaviour {

	public TapGesture singleTap;

	public GameObject Demo1;
	public GameObject Demo2;

	// Use this for initialization
	void Start () {
		
		singleTap.Tapped += (object sender, System.EventArgs e) => 
		{
			TouchHit hit;
			singleTap.GetTargetHitResult(out hit);
			if(Demo1.activeInHierarchy){
				Demo1.SetActive(false);
				Demo2.SetActive(true);
			}

			else{
				Demo1.SetActive(true);
				Demo2.SetActive(false);
			}

			Debug.Log(Demo1.activeInHierarchy);
			Debug.Log(Demo2.activeInHierarchy);
		};
	}
	
	// Update is called once per frame
	void Update () {

		
	}
}
