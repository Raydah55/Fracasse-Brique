using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    [SerializeField] private int rows = 3;
    [SerializeField] private int columns = 5;
    [SerializeField] private Brick brick;
    [HideInInspector]
    public int nbBricksLeft;
    [SerializeField] private Transform origin;
    [SerializeField] private Sprite[] sprites;

    void Start()
    {
        nbBricksLeft = rows * columns;
        LoadBricks();
    }

    void LoadBricks(){
        Vector2 size = brick.GetComponent<Renderer>().bounds.size;
        Debug.Log(size);
        for (int i = 0; i < rows;i++){
            for (int j = 0; j < columns; j++){
                Vector2 position = new Vector2(origin.position.x + (size.x / 2f) + (j * (size.x + 0.05f)), origin.position.y - (size.y / 2f) - (i * (size.y + 0.05f)));
                Brick brickObject = Instantiate(brick,position,Quaternion.identity);
                //Sprite aléatoire pour la brique
                brickObject.GetComponent<SpriteRenderer>().sprite = sprites[GetRandomSprite()];
            }
        }
    }

    int GetRandomSprite(){
        return Random.Range(0, sprites.Length);
    }
    
}
