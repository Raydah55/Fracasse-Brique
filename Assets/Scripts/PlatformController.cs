using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private float speed = 4f;

    private void Start()
    {
        
    }

    private void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * horizontal * Time.deltaTime * speed);
    }

    public float Speed {
        get { return speed; }
        set { speed = value; }
    }
}
