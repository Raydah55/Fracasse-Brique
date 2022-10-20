using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText;
    private static GameManager instance;

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
}
