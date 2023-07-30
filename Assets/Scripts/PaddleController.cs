using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    // パドルの速度
    public float speed = 10.0f;
    // パドルの移動可能なX軸上の最小値
    private float minX;
    // パドルの移動可能なX軸上の最大値
    private float maxX;

    void Start()
    {
        // カメラのビューポートをワールド座標に変換して、パドルが画面外に出ないようにする
        minX = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x;
        maxX = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
    }

    // Update is called once per frame
    void Update()
    {
        // マウスの位置を取得し、それに基づいてパドルの位置を更新
        Vector2 paddlePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        // パドルが画面外に出ないようにする
        paddlePos.x = Mathf.Clamp(paddlePos.x, minX, maxX);

        // パドルの位置を更新
        transform.position = new Vector2(paddlePos.x, transform.position.y);
    }
}
