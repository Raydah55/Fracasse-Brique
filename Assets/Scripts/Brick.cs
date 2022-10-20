using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int score = 5000;
    

    void OnCollisionEnter2D(Collision2D col){
        GameManager.Instance.SetScore(GameManager.Instance.GetScore()+score);
        Destroy(gameObject);
    }
}
