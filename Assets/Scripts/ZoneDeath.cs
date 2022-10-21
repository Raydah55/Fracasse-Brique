using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDeath : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collider){
        GameManager.Instance.PlayerDie();
    }
}
