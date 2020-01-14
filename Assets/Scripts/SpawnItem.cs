using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{

    float SpawnPositionX;
    float SpawnPositionY;
    float SpawnPositionZ;  
    int Lane;

    Vector3 TreeLastPosition;

    Renderer Renderer;

    public GameObject[] Items;

    public GameObject Trees;

    public void Start(){
        SpawnItems();
        Renderer = GetComponent<Renderer>();
        StartCoroutine(SpawnTrees());
    }

    public void SpawnItems(){
      for(int i = 0; i < 1; i++){
          int Item = Random.Range(0,4);
          Lane = Random.Range(0,3);

          if(Lane==0){
              SpawnPositionX = -12.5f;
          }

          else if(Lane==1){
              SpawnPositionX = 0f;
          }

          else if(Lane==2){
              SpawnPositionX = 12.5f;
          }

          if(Item==1 || Item==2 || Item==3 ){
              for (int x=0;x<Random.Range(1,3); x++){
                  Lane = Random.Range(0,2);

                    if(Lane==0){
                        SpawnPositionX = -12.5f;
                    }

                    else if(Lane==1){
                        SpawnPositionX = 0f;
                    }

                    else if(Lane==2){
                        SpawnPositionX = 12.5f;
                    }

                    Instantiate(Items[1], new Vector3(SpawnPositionX, -55f, transform.position.z+Random.Range(100f, 400f)), Quaternion.identity);
              }
          }else{
              Instantiate(Items[0], new Vector3(SpawnPositionX, -55f, transform.position.z+Random.Range(100f, 400f)), Quaternion.identity);
          }   
          
      }
    }

    IEnumerator SpawnTrees(){
        yield return new WaitForSeconds(0f);
        Instantiate(Trees, new Vector3(transform.position.x+35f, -35f, transform.position.z+Random.Range(100f,200f) ), Quaternion.identity);
        Instantiate(Trees, new Vector3(transform.position.x-35f , -35f, transform.position.z+Random.Range(20f,100f)), Quaternion.identity);
        
        var TreePosition =0; 
        /*for(int i = 0; i < Random.Range(2, 4); i++){
            TreePosition = Random.Range(0,7);
            
            
            if(TreePosition==0  || TreePosition==2 || TreePosition==4 || TreePosition==6){
                
            } 
            
            else if(TreePosition==1 || TreePosition==3 || TreePosition==5 || TreePosition==7){
                
            }
        }*/
    }
}
