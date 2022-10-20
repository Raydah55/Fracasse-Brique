using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public BrickManager brickManager;
    public GameObject spawn;
    public GameObject ball;
    public float delayReload = 1f;

    private int score = 0;
    private static GameManager instance;
    private int nbBricksLeft;
    private int nbBricksTotal;
    private bool startReloading = false;

    void Awake()
    {
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
    }

    IEnumerator ReloadLevel(){
        yield return  new WaitForSeconds(delayReload);
        ball.transform.position = spawn.transform.position;
        ball.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        ball.GetComponent<BallController>().LaunchBall();
        brickManager.LoadBricks();
        ResetNbBricksLeft();
        startReloading = false;
    }
}
