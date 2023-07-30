using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 initialDirection = new Vector2(2f, -1f);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    void LaunchBall()
    {
        Debug.Log("LaunchBall");
        rb.velocity = initialDirection.normalized * speed;
    }

    void Update()
    {
        if(transform.position.y < -5.5f)
        {
            ResetBall();
        }
    }

    void ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = new Vector2(0, -2.5f);
        // ボールが画面外に出たらライフを減らす
        GameManager.lives--;
        if(GameManager.lives > 0)
        {
            LaunchBall();
        }
    }
}
