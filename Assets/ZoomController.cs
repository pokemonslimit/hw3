using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomController : MonoBehaviour {
	
	public Transform target; // 要觀看的目標，請從外部拉進來

	float temp;
	bool sw = false;

	private float speed =0.1f;


	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {

			if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
			{
				// Get movement of the finger since last frame
				Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

				// Move object across XY plane

			if(touchDeltaPosition.x>=0&&Mathf.Abs(touchDeltaPosition.y)<=5)
			transform.RotateAround(target.transform.position,new Vector3 (0,1,0),300*Time.deltaTime);

			if(touchDeltaPosition.x<0&&Mathf.Abs(touchDeltaPosition.y)<=5)
			transform.RotateAround(target.transform.position,new Vector3 (0,-1,0),300*Time.deltaTime);
			
			Debug.Log (touchDeltaPosition);
			}

		if(Input.touchCount >= 2){
			float temp2 = Vector2.Distance (Input.GetTouch (0).position, Input.GetTouch (1).position);
			float cameraScale = temp2 - temp;
			temp = temp2;
			if(sw){
				transform.localPosition = Vector3.MoveTowards (transform.position, target.position, cameraScale * Time.deltaTime / 2);
			}
			sw = true;
		}else{
			sw = false;
		}

	


	}

	}

