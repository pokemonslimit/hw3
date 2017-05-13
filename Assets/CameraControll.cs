using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour {
	public GameObject target;
	public float xpos,ypos,zpos;
	float distance=1.5f,cam_posy,cam_posz;
	Vector2 startPos;
	Vector2 direction,oldPosition1,oldPosition2;
	Vector3 UpdatePos;
	float sum_deltaPos = 0;
	int abs=1, state=0;
	bool dir=false;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (target.transform.position.x,ypos,target.transform.position.z-zpos);
		UpdatePos = transform.position;
		transform.LookAt(target.transform.position);

	}

	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 1) {
			if(Input.GetTouch(0).phase==TouchPhase.Moved||Input.GetTouch(1).phase==TouchPhase.Moved){
				Touch touch1 = Input.GetTouch(0);
				Touch touch2 = Input.GetTouch(1);

				if(touch1.deltaPosition.y>0)abs=1;
				else abs=-1;

				sum_deltaPos = Mathf.Abs(touch1.deltaPosition.x)+Mathf.Abs(touch1.deltaPosition.y);


				if(state!=1){//rotate
					transform.RotateAround(target.transform.position,Vector3.up, sum_deltaPos*abs);
					UpdatePos=new Vector3(transform.position.x-target.transform.position.x,0,transform.position.z-target.transform.position.z);
				}

				oldPosition1=touch1.position;
				oldPosition2=touch2.position;
			}
		}
		else{
			dir=false;
			state=0;
		}
	}
	void LateUpdate () {
		float x, z;
		x = UpdatePos.x + target.transform.position.x;
		z = UpdatePos.z + target.transform.position.z;
		transform.position =new Vector3 (x,ypos,z);
	}

	bool isEnlarge(Vector2 oP1,Vector2 oP2,Vector2 nP1,Vector2 nP2){
		//函数传入上一次触摸两点的位置与本次触摸两点的位置计算出用户的手势
		float leng1 =Mathf.Sqrt((oP1.x-oP2.x)*(oP1.x-oP2.x)+(oP1.y-oP2.y)*(oP1.y-oP2.y));
		float leng2 =Mathf.Sqrt((nP1.x-nP2.x)*(nP1.x-nP2.x)+(nP1.y-nP2.y)*(nP1.y-nP2.y));
		if(-1>leng1-leng2){
			//放大手势
			state=1;
			return true;
		}else if(1<leng1-leng2){
			//缩小手势
			state=1;
			return false;
		}
		else{
			state=2;
			return false;
		}
	}
}

