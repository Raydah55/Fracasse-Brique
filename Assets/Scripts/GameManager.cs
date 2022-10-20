using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public BrickManager brickManager;

    private int score = 0;
    private static GameManager instance;
    private int nbBricksLeft;
    private int nbBricksTotal;

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
        if (nbBricksLeft == 0){
            ReloadLevel();
        }
    }

    void ReloadLevel(){
        brickManager.LoadBricks();
        ResetNbBricksLeft();
    }
}
