using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
 void Update(){
     transform.position = new Vector3(transform.position.x+1f, 0, 0);
 }
}
