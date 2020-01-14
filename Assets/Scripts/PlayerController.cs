using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 _Velocity;
    Rigidbody MyRigidBody;

	void Start () {
        MyRigidBody = GetComponent<Rigidbody>();
	}

    public void Move(Vector3 Velocity) {
        _Velocity = Velocity;
        Debug.Log(Velocity);
    }

    public void Turn(Vector3 Velocity) {
        _Velocity = Velocity;
    }

    public void FixedUpdate()
    {
        MyRigidBody.MovePosition(MyRigidBody.position + _Velocity * Time.fixedDeltaTime);
    }
}
