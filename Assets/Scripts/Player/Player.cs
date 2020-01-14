/*
    Author Sibongiseni Tembe - Seni.tembe@gmail.com
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{   
    /*
        game objects
    */

    //explosion game objects
    public GameObject[] Explosion;
    public GameObject ScoreUI0;
    public GameObject ScoreUI1;
    public GameObject ScoreUI2;
    public GameObject ScoreUI3;
    public GameObject ScoreUI4;
    public GameObject ScoreUI5;    
    
    //fireworks game objects
    public GameObject[] FireWorks;

    public GameObject[] PointsUI;

    //Ui to spawn when player collects 25 suns
    public GameObject WinUI;

    //ui used during game play to set false 
    public GameObject GamePlayUI;
    
    //game object skyline
    public GameObject SkyLine;
    
    //main camera
    //public GameObject MainCamera;

    public GameObject TextObject; 

    //player speed
    public float SpeedZ = 0.1f;
    
    PlayerController Controller;
    
    public Text Points;
    public Text Message;
    int Life;
    int suns;

    //player position
    float PlayerPositionX;
    float PlayerPositionZ;
    
    //skyline
    float SkyLinePositionZ;

    //playerlife UI
    public Text LifeText;
    
    //did player collect 25 suns?.
    bool Win;

    //objects to spaen when player touches obsticle
    GameObject[] ObsticleTouch;
    
    //objects to spaen when player touches Sun
    GameObject[] SunTouch;  
    Rigidbody rb;
    
    //Sound
    public AudioSource[] SunSound;
    public AudioSource[] DamageSound;
    public AudioSource CarSound;
    public AudioSource PowerUpSound;

    // Use this for initialization
	void Start () {
        //CarSound.Play(0);
        Controller = GetComponent<PlayerController>();
        suns=0;
        Life=3;
        LifeText.text = Life.ToString();
        rb = GetComponent<Rigidbody>();
        ScoreUI0.SetActive(true);
        ScoreUI1.SetActive(false);
        ScoreUI2.SetActive(false);
        ScoreUI3.SetActive(false);
        ScoreUI4.SetActive(false);
        ScoreUI5.SetActive(false);
        Win=false;
    }

    IEnumerator ShowText(string mes){
        var Message = Instantiate(TextObject, new Vector3(transform.position.x, transform.position.y + 12f, transform.position.z), Quaternion.identity, transform);   
        Message.GetComponent<TextMesh>().text = mes;
        yield return new WaitForSeconds(2.5f);
        Destroy(Message);
    }
	
	// Update is called once per frame
    void Update(){
        Debug.Log("Update time :" + Time.deltaTime);
        /*PlayerPositionZ = transform.position.z + SpeedZ;
        SkyLinePositionZ = SkyLine.transform.position.z+SpeedZ;
        PlayerPositionX = transform.position.x;

        if(Input.GetKey(KeyCode.Return) && Win){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(Input.GetKeyDown("right")){
            if(transform.position.x < 10){
                PlayerPositionX = transform.position.x + 12.5f;
            }
        }

        else if(Input.GetKeyDown("left")){
            if(transform.position.x > - 10){
                PlayerPositionX = transform.position.x -12.5f;
            }
        }
        
        transform.position = new Vector3(PlayerPositionX , -55f , PlayerPositionZ );
        //transform.position = Vector3.Lerp(transform.position, new Vector3(PlayerPositionX, -55f ,PlayerPositionZ), Time.deltaTime * 1.5f);
        SkyLine.transform.position= new Vector3(SkyLine.transform.position.x, SkyLine.transform.position.y, SkyLinePositionZ );
    
        if(Input.GetKey(KeyCode.Return) && Win){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } */
    }

    void FixedUpdate(){
        Debug.Log("FixedUpdate time :" + Time.deltaTime);

        //PlayerPositionZ = transform.position.z + SpeedZ;
        SkyLinePositionZ = SkyLine.transform.position.z+SpeedZ;
        PlayerPositionX = transform.position.x;

        if(Input.GetKey(KeyCode.Return) && Win){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(Input.GetKeyDown("right")){
            if(transform.position.x < 10){
                PlayerPositionX = transform.position.x + 12.5f;
            }
        }

        else if(Input.GetKeyDown("left")){
            if(transform.position.x > - 10){
                PlayerPositionX = transform.position.x -12.5f;
            }
        }
        
        transform.position = new Vector3(PlayerPositionX , -55f , transform.position.z );
        //transform.position = Vector3.Lerp(transform.position, new Vector3(PlayerPositionX, -55f ,PlayerPositionZ), Time.deltaTime * 1.5f);
        SkyLine.transform.position= new Vector3(SkyLine.transform.position.x, SkyLine.transform.position.y, SkyLinePositionZ );
    
        if(Input.GetKey(KeyCode.Return) && Win){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    //increase player speed 
    public void IncreaseSpeed(){
        SpeedZ=SpeedZ+0.2f;
    }

    //destroy the player
    public void DestroyPlayer(){
        Destroy(gameObject);
    }

    //spawn fireworks
    IEnumerator StartFireWorks(){
        yield return new WaitForSeconds(2f);
        Win =true;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        /*for(int x = 0; x<Random.Range(10, 50); x++){
            for(int i = 0; i<FireWorks.Length; i++){
                Instantiate(FireWorks[i], new Vector3(Random.Range(-100f, 100f), Random.Range(9f, 100f), transform.position.z+Random.Range(10f,100f)), Quaternion.identity);          
            }  
            yield return new WaitForSeconds(1);        
        }
        yield return new WaitForSeconds(10);*/
        // 
    }

    //make object blink when it touches object
    IEnumerator DoBlinks(float duration, float blinkTime) {
         while (duration > 0f) {
                 duration -= Time.deltaTime;
      
            //toggle renderer
            //Game = !renderer.enabled;
      
            //wait for a bit
            yield return new WaitForSeconds(blinkTime);
         }
  
         //make sure renderer is enabled when we exit
         //renderer.enabled = true;
     }

    //on trigger add points or minus life
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Obsticle")
        {
            DamageSound[Random.Range(0,DamageSound.Length)].Play(0);
            Life--;
            LifeText.text = Life.ToString();
            var select = Random.Range(0,3);

            if(select==0){
                
                StartCoroutine(ShowText("OUCH!"));
            }

            else if(select==1){
                StartCoroutine(ShowText("BURN!"));
            }

            else if(select==2){
                StartCoroutine(ShowText("GLOBAL WARNING!"));
            }

            if(Life==0){
                CarSound.Stop();
                SpeedZ=0;
                gameObject.SetActive(false);
            }
        }

        else if(collision.tag == "Point"){
            SunSound[Random.Range(0,SunSound.Length)].Play(0);    
            suns++;
            IncreaseSpeed();

            if(suns==4 || suns==8 || suns==13 || suns==18 || suns==23){
                var select = Random.Range(0,3);

                if(select==0){
                    StartCoroutine(ShowText("BEAM DREAM!"));
                }

                else if(select==1){
                    StartCoroutine(ShowText("STAY LIT!"));
                }

                else if(select==2){
                    StartCoroutine(ShowText("NO SHADE!"));
                }
            }

            if(suns==0){
                ScoreUI0.SetActive(true);
                ScoreUI1.SetActive(false);
                ScoreUI2.SetActive(false);
                ScoreUI3.SetActive(false);
                ScoreUI4.SetActive(false);
                ScoreUI5.SetActive(false);
            }
            
            else if(suns==6){
                PowerUpSound.Play(0);
                ScoreUI0.SetActive(false);
                ScoreUI1.SetActive(true);
                ScoreUI2.SetActive(false);
                ScoreUI3.SetActive(false);
                ScoreUI4.SetActive(false);
                ScoreUI5.SetActive(false);
            }


            else if(suns==12){
                PowerUpSound.Play(0);
                ScoreUI0.SetActive(false);
                ScoreUI1.SetActive(false);
                ScoreUI2.SetActive(true);
                ScoreUI3.SetActive(false);
                ScoreUI4.SetActive(false);
                ScoreUI5.SetActive(false);
            }

            else if(suns==18){
                PowerUpSound.Play(0);
                ScoreUI0.SetActive(false);
                ScoreUI1.SetActive(false);
                ScoreUI2.SetActive(false);
                ScoreUI3.SetActive(true);
                ScoreUI4.SetActive(false);
                ScoreUI5.SetActive(false);
            }

            else if(suns==24){
                PowerUpSound.Play(0);
                ScoreUI0.SetActive(false);
                ScoreUI1.SetActive(false);
                ScoreUI2.SetActive(false);
                ScoreUI3.SetActive(false);
                ScoreUI4.SetActive(true);
                ScoreUI5.SetActive(false);
            }

            else if(suns==30){
                PowerUpSound.Play(0);
                ScoreUI0.SetActive(false);
                ScoreUI1.SetActive(false);
                ScoreUI2.SetActive(false);
                ScoreUI3.SetActive(false);
                ScoreUI4.SetActive(false);
                ScoreUI5.SetActive(true);
            }
            
            if(suns==30){
                CarSound.Stop();
                SpeedZ=0;
                WinUI.SetActive(true);
                GamePlayUI.SetActive(false);
                StartCoroutine(StartFireWorks());
            }
        }
    }
}
