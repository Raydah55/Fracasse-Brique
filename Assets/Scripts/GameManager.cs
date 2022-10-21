using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public BrickManager brickManager;
    public GameObject spawn;
    public GameObject ball;
    public float delayReload = 1f;
    public GameObject pause;
    private bool isInPause = false;

    [SerializeField] private int health = 1;
    [SerializeField] private string sceneName;
    private int score = 0;
    private static GameManager instance;
    private int nbBricksLeft;
    private int nbBricksTotal;
    private bool startReloading = false;

    void Awake()
    {
        Time.timeScale = 1;
        if (instance != null && instance != this)
             Destroy(gameObject);
         instance = this;
    }

    public static GameManager Instance { 
        get
        {
            return instance;
        }    
    }

    void Start(){
        scoreText.SetText(""+score);
    }
    
    public int GetScore(){
        return score;
    }

    public void SetScore(int newScore){
        score = newScore;
        scoreText.SetText(""+score);
    }

    public int GetNbBricksLeft(){
        return nbBricksLeft;
    }

    public void RemoveBrick(){
        nbBricksLeft--;
        if (nbBricksLeft <= 10){
            AudioManager.instance.Stop("music");
            AudioManager.instance.Play("lowlife");
        }
    }

    public void ResetNbBricksLeft(){
        nbBricksLeft = nbBricksTotal;
    }

    public void SetNbBricksTotal(int nbBricks){
        nbBricksTotal = nbBricks;
    }

    public int GetNbBricksTotal(){
        return nbBricksTotal;
    }

    void Update (){
        if (nbBricksLeft == 0 && !startReloading){
            startReloading = true;
            StartCoroutine(ReloadLevel());
        }
        if(Input.GetKeyDown("escape")){
            Pause(!isInPause);
        }
    }

    IEnumerator ReloadLevel(){
        yield return  new WaitForSeconds(delayReload);
        AudioManager.instance.Stop("lowlife");
        AudioManager.instance.Stop("music");
        AudioManager.instance.Play("music");
        ball.transform.position = spawn.transform.position;
        ball.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        ball.GetComponent<BallController>().LaunchBall();
        brickManager.LoadBricks();
        ResetNbBricksLeft();
        startReloading = false;
    }

    public void PlayerDie(){
        health = health - 1;
        if(health <= 0){
            ChangeScene(sceneName);
        }
    }

    public void ChangeScene(string scene){
        SceneManager.LoadScene(scene);
    }

    public void Pause(bool inPause){
        isInPause = inPause;
        pause.SetActive(inPause);
        if (inPause){
            Time.timeScale = 0;
            
        } else {
            Time.timeScale = 1;
        }
    }
}
