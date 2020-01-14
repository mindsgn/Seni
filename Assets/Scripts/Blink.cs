using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public GameObject Object;
    int i = 0;

    void Start(){
    }

    // Update is called once per frame
    void Update()
    {
        if(i==0){
            i=1;
            StartCoroutine(Blinke());
        }
    }

    IEnumerator Blinke(){
            Object.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            Object.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            i=0;
    }
}
