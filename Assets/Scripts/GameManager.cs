using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public GameObject Player;
  public GameObject[] Roads;
  public GameObject MainCamera;

  //sound
  public AudioSource buttonClick;
  public AudioSource[] CountDownMusic;  
  public AudioSource MenuSoundS;  
  public AudioSource BackGroundMusic1;
  public AudioSource BackGroundMusic2;
  public AudioSource BackGroundMusic3;

  public GameObject StartUI;
  public GameObject PlayUI;
  public GameObject CountDownUI;
  public GameObject GameOverUI;

  //Count Down assets
  public GameObject CountDown1;
  public GameObject CountDown2;
  public GameObject CountDown3;
  public GameObject CountDown4; 

  public GameObject MenuSound; 

  //can I start game?
  bool CanIStart;
  
  //Text
  public Text Score;
  public Text CountDownText;

  public int Points;

  Vector3 RoadPosition;
  Vector3 refPos;

  CameraController CameraController;

  bool isReady = false;

  public enum GameManagerState{
    Opening, StartScreen, Play, GameOver, Win, CountDown,    
  }   

  GameManagerState GameState;
  
  public GameObject CameraPosition;

  //instruction 
  public GameObject Instructions1;
  public GameObject Instructions2;
  public GameObject Instructions3;
  public GameObject StartButton;
  public GameObject[] blink;

  public GameObject[] clouds_;  
  
  private void Start(){
    //source = GetComponent<AudioSource>();  
    Cursor.visible = false;
    //Screen.showCursor = false;
    CanIStart = false;
    Instructions1.SetActive(false);
    Instructions2.SetActive(false);
    StartButton.SetActive(false);
    CountDown1.SetActive(false);
    CountDown2.SetActive(false);
    CountDown3.SetActive(false);
    CountDown4.SetActive(false);
    MainCamera.GetComponent<CameraFollow>().enabled = false;
    StartUI.SetActive(true);
    GameState = GameManagerState.Opening;    
    RoadPosition = new Vector3(0, 0, 600f);  
    UpdateGameState();
    BackGroundMusic1.Play(0);
    for(int i = 0; i < clouds_.Length ;i++){
        clouds_[i].SetActive(false);
    }
  }

  void TriggerWin() {
      StartCoroutine(Win());
  }

  IEnumerator Win(){
      yield return new WaitForSeconds(3f);
  }
  
  //game count down  
  IEnumerator CountDown(){
      GameState = GameManagerState.CountDown;
      UpdateGameState();
      SpawnRoads();
      MainCamera.GetComponent<CameraFollow>().enabled = true;
      for(int i = 3; i > 0; i--){
          CountDownMusic[0].Play(0);
          if(i==3){
            CountDown3.SetActive(true);
            yield return new WaitForSeconds(1.2f);
            CountDown3.SetActive(false);
          }

          else if(i==2){
            CountDown2.SetActive(true);
            yield return new WaitForSeconds(1.2f);
            CountDown2.SetActive(false);
          }

          else if(i==1){
            CountDown1.SetActive(true);
            yield return new WaitForSeconds(1.2f);
            CountDown1.SetActive(false);
          }
      }

      CountDownMusic[1].Play(0);
      CountDown4.SetActive(true);
      yield return new WaitForSeconds(1.2f);
      StartGame();
      CountDown4.SetActive(false);
  }

    //game count down  
  IEnumerator StartGameOver(){
      CanIStart = false;
      GameState = GameManagerState.GameOver;
      UpdateGameState();  
      yield return new WaitForSeconds(0);
  }

  IEnumerator DestroyAllObjects(){
    yield return new WaitForSeconds(5);
    GameObject[] Objects;

    Objects =  GameObject.FindGameObjectsWithTag ("Player");
    for(var i = 0 ; i < Objects.Length ; i ++)
        Destroy(Objects[i]);

    Objects =  GameObject.FindGameObjectsWithTag ("Road");
    for(var i = 0 ; i < Objects.Length ; i ++)
        Destroy(Objects[i]);
    
    Objects =  GameObject.FindGameObjectsWithTag ("Point");
    for(var i = 0 ; i < Objects.Length ; i ++)
        Destroy(Objects[i]);

    Objects =  GameObject.FindGameObjectsWithTag ("Obsticle");
    for(var i = 0 ; i < Objects.Length ; i ++)
        Destroy(Objects[i]);   
    
    Objects =  GameObject.FindGameObjectsWithTag ("Explosion");
    for(var i = 0 ; i < Objects.Length ; i ++)
        Destroy(Objects[i]);   
    
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }

  void UpdateGameState() {
        switch (GameState) {
            case GameManagerState.Opening:
                StartUI.SetActive(true);
                break;
            case GameManagerState.StartScreen:
                buttonClick.Play(0);
                break;    
            case GameManagerState.CountDown:
                BackGroundMusic1.Stop();
                BackGroundMusic2.Play();
                buttonClick.Play(0);
                StartUI.SetActive(false);
                CountDownUI.SetActive(true);
                PlayUI.SetActive(true);
                Player.SetActive(true);
                SpawnRoads();
                MainCamera.GetComponent<CameraController>().enabled = true;
                break;
            case GameManagerState.Play:
                PlayUI.SetActive(true);
                CountDownUI.SetActive(false);
                MainCamera.GetComponent<CameraFollow>().enabled = true;
                break;
            case GameManagerState.GameOver:
                BackGroundMusic2.Stop();
                BackGroundMusic3.Play();
                GameOverUI.SetActive(true);
                PlayUI.SetActive(false);
                break;
            case GameManagerState.Win:
                break;
        }
  }

  public void SetGameManager(GameManagerState State) {
        GameState = State;
        UpdateGameState();
  }

  public void StartGame() {
        GameState = GameManagerState.Play;
        ///StartUI.SetActive(false);
        UpdateGameState();
  }

  public void Game() {
        GameState = GameManagerState.Play;
        ///StartUI.SetActive(false);
        UpdateGameState();
  }

  public void ChangeGameState() {
        SetGameManager(GameManagerState.Opening);
  }
  
  void Update(){
        if(Input.GetKey(KeyCode.Return) && string.Compare(GameState.ToString(), "Opening") == 0){
            GameState = GameManagerState.StartScreen;   
            UpdateGameState();
        }

        if(Input.GetKey(KeyCode.Return) && string.Compare(GameState.ToString(), "GameOver") == 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(string.Compare(GameState.ToString(), "StartScreen") == 0){
            StartUI.transform.position = Vector3.Lerp(StartUI.transform.position, new Vector3(StartUI.transform.position.x, 1600f ,StartUI.transform.position.z), Time.deltaTime * 1.5f);
            StartCoroutine(ScreenTwoAnimation());
        }

        if(Input.GetKey(KeyCode.Return) && string.Compare(GameState.ToString(), "StartScreen" ) == 0 && CanIStart){
            StartCoroutine(CountDown());
        }

        if(GameObject.FindGameObjectWithTag("Player")){
            GameObject PlayerObject = GameObject.FindGameObjectWithTag("Player");
            foreach(GameObject road in GameObject.FindGameObjectsWithTag("Road"))
            {
                if(road.transform.position.z + 150f  < PlayerObject.transform.position.z){
                    Destroy(road);
                    SpawnRoad();
                }
            }

            foreach(GameObject tree in GameObject.FindGameObjectsWithTag("tree"))
            {
                if(tree.transform.position.z + 150f  < PlayerObject.transform.position.z){
                    Destroy(tree);
                }
            }


            foreach(GameObject Obsticle in GameObject.FindGameObjectsWithTag("Obsticle"))
            {
                if(Obsticle.transform.position.z + 150f  < PlayerObject.transform.position.z){
                    Destroy(Obsticle);
                }
            }

            foreach(GameObject Point in GameObject.FindGameObjectsWithTag("Point"))
            {
                if(Point.transform.position.z + 150f  < PlayerObject.transform.position.z){
                    Destroy(Point);
                }
            }
        }

        else if(!GameObject.FindGameObjectWithTag("Player") && string.Compare(GameState.ToString(), "Play") == 0){
            StartCoroutine(DestroyAllObjects());
            StartCoroutine(StartGameOver());
        }
  }

  //Decrease Points
  public void DecreasePoints(){
      Points--;
  }
  
  //spawn Roads at the start of the game
  public void SpawnRoads(){
    for(int i = 0; i < 1; i++){
        GameObject LastPosition = Instantiate(Roads[Random.Range(0, Roads.Length)], new Vector3(0f, -56.4f, RoadPosition.z -250f), Quaternion.identity);
        RoadPosition = new Vector3(LastPosition.transform.position.x, LastPosition.transform.position.y, LastPosition.transform.position.z + 100.0f);
    }
  }
  
  //spawn more roads while on Play
  public void SpawnRoad(){
        GameObject LastPosition = Instantiate(Roads[0], new Vector3(0f, -56.4f, RoadPosition.z+ 250.0f), Quaternion.identity);
        RoadPosition = new Vector3(LastPosition.transform.position.x, LastPosition.transform.position.y, LastPosition.transform.position.z);
  }

  public void SpawnPlayer(){
    Instantiate(Player, new Vector3(0f, -47.5f, 0f), Quaternion.identity);
  }

  IEnumerator ScreenTwoAnimation(){ 
    yield return new WaitForSeconds(2.5f);
    Instructions1.SetActive(true);
    yield return new WaitForSeconds(2f);
    Instructions2.SetActive(true);
    yield return new WaitForSeconds(2f);
    Instructions3.SetActive(true);
    yield return new WaitForSeconds(2f);
    //MenuSoundS.Play();
    StartButton.SetActive(true);

    for(int i = 0; i < clouds_.Length ;i++){
        clouds_[i].SetActive(true);
    }
    
    CanIStart= true;

    for(int x = 0; x<1000; x++){
        for(int i = 0; i<blink.Length; i++){
            blink[i].SetActive(false);
            yield return new WaitForSeconds(3f);
            blink[i].SetActive(true);
            yield return new WaitForSeconds(1f);
        }   
    }
  }
}