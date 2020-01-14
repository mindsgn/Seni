using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{   
    public Transform target;
    public float movementTime=1;
    public float rotationSpeed=5.5f;
     
    Vector3 refPos;
    Vector3 refRot;
 
    void Update ()
    {
        //transform.position = Vector3.SmoothDamp(transform.position, target.position, ref refPos, movementTime); 
        //transform.rotation =  Quaternion.Slerp(transform.rotation, target.rotation, rotationSpeed *  Time.deltaTime);
    }

    public void FaceUp(){
        //transform.rotation(0,0,0);
    }

    public void FaceDown(){
        //transform.rotation(0,0,0);
    }

    public void FollowPlayer(){
        //transform.rotation(0,0,0);
    }
}
