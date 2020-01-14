using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClouds : MonoBehaviour
{
    public GameObject[] Clouds;
    void Update(){
        Instantiate(Clouds[Random.Range(0, Clouds.Length)], new Vector3(0,0,1), Quaternion.identity);
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown(){
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}