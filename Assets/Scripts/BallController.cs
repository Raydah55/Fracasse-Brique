using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 300f;
    [SerializeField] private float speedRotation = 18f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke(nameof(SetRandomTrajectory), 1f);
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0f,0f,speedRotation * Time.deltaTime));
    }

    private void SetRandomTrajectory()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-0.75f, 0.75f);
        force.y = -1;

        rb.AddForce(force.normalized * speed);
    }

    public void LaunchBall(){
        Invoke(nameof(SetRandomTrajectory), 1f);
    }
}
