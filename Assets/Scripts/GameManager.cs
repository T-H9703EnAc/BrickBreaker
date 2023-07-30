using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 現在のブロックの数
    public static int blockCount = 0;

    // ゲームがクリアされたかどうか
    public static bool isGameCleared = false;

    // ゲームオーバーかどうか
    public static bool isGameOver = false;

    // プレイヤーのライフ数
    public static int lives = 3;

    // ゲームクリアメッセージを表示するためのTextコンポーネント
    public Text clearText;

    // ゲームオーバーメッセージを表示するためのTextコンポーネント
    public Text gameOverText;

    // プレイヤーのライフを表示するためのTextコンポーネント
    public Text livesText;

    void Start()
    {
        // 初期状態ではゲームクリアメッセージは非表示にします
        clearText.enabled = false;
        gameOverText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ブロックが0になったらゲームクリア
        if (blockCount <= 0 && !isGameCleared)
        {
            // ゲームクリアメッセージを表示する
            isGameCleared = true;
            clearText.enabled = true;
        }

        // ライフが0になったらゲームオーバー
        if (lives <= 0 && !isGameOver)
        {
            isGameOver = true;
            gameOverText.enabled = true; // ゲームオーバーメッセージを表示する
        }

        // プレイヤーのライフを表示する
        livesText.text = "Lives: " + lives;

    }
}
