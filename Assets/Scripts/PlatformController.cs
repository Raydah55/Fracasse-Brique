using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

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
        float width = Camera.main.aspect * Camera.main.orthographicSize * 2.0f;
        float objectWidth = GetComponent<Collider2D>().bounds.size.x;
        Vector3 depl = Vector3.right * horizontal * Time.deltaTime * speed;
        float cameraMin = Camera.main.transform.position.x - (width /2f);
        float cameraMax = Camera.main.transform.position.x + (width /2f); 
        float platformMin = transform.position.x - objectWidth/2f;
        float platformMax = transform.position.x + objectWidth/2f;
        if (!((horizontal < 0 && cameraMin + 0.48f > platformMin + depl.x) || (horizontal > 0 && cameraMax -0.48f < platformMax + depl.x))){
            transform.Translate(Vector3.right * horizontal * Time.deltaTime * speed);
        }
    }

    public float Speed {
        get { return speed; }
        set { speed = value; }
    }
}
