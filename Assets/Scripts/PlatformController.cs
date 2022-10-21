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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BallController ball = collision.gameObject.GetComponent<BallController>();

        if (ball != null) {
            Vector3 paddlePosition = this.transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;
            float offset = paddlePosition.x - contactPoint.x;
            float width = collision.otherCollider.bounds.size.x / 2f;
            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.RB.velocity);
            float bounceAngle = (offset / width) * ball.MaxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -ball.MaxBounceAngle, ball.MaxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.RB.velocity = rotation * Vector2.up * ball.RB.velocity.magnitude;
        }
    }

    public float Speed {
        get { return speed; }
        set { speed = value; }
    }
}
