using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    //keep player moving foward
    public float Speed = 0.005f;
    private float positionZ = 0.0f;
    
    // Update is called once per frame
    void Update()
    {
        positionZ = positionZ + Speed;
        transform.position = new Vector3(transform.position.x, transform.position.y, positionZ);
    }
}
