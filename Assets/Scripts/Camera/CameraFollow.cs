using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
 	
	Transform target;
	//GameObject Player;
	public float height = 5.0f;
	public float distance = 10.0f;
	public float rotationDamping;
	public float heightDamping;	

	Vector3 refPos;
    Vector3 refRot;

	Vector3 CameraCurrentPosition;

	void Start(){
		Debug.Log(transform.position);
		//CameraCurrentPosition = transform.position;
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void LateUpdate(){
		if(!target){
			if(GameObject.FindGameObjectWithTag("Player")){
				target = GameObject.FindGameObjectWithTag("Player").transform;
			}
		}else{
			/*
			var wantedRotationAngle = target.eulerAngles.y;
			var wantedHeight = target.position.y + height;

			var currentRotationAngle = transform.eulerAngles.y;
			var currentHeight = transform.position.y;

			currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * 0.1f);
			currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * 1.0f);

			var currentRotation = Quaternion.Euler(0,currentRotationAngle, 0);*/

			//transform.position = target.position;
			//transform.position -= currentRotation * Vector3.forward * distance;
			

			//Vector3.SmoothDamp(transform.position, target.position, ref refPos, movementTime);
			transform.position = new Vector3(transform.position.x, transform.position.y, target.transform.position.z -30f);
			//transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y , target.transform.position.z), Time.deltaTime * 1f);
			//transform.position = Vector3.Lerp();	

			//transform.position = Vector3.SmoothDamp(transform.position, target.position, ref refPos, 1f); 
			//transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rotationDamping * 1.0f);
		}
	}
}
