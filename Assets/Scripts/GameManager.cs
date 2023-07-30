using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    // 再プレイボタンへの参照
    public Button replayButton;
    // タイトルボタンへの参照
    public Button titleButton;

    void Start()
    {
        // 初期状態ではゲームクリアメッセージは非表示にします
        clearText.enabled = false;
        gameOverText.enabled = false;
        replayButton.gameObject.SetActive(false);
        titleButton.gameObject.SetActive(false);
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
            replayButton.gameObject.SetActive(true);
            titleButton.gameObject.SetActive(true);
            // ゲームの時間を停止
            Time.timeScale = 0;
        }

        // ライフが0になったらゲームオーバー
        if (lives <= 0 && !isGameOver)
        {
            isGameOver = true;
            gameOverText.enabled = true; // ゲームオーバーメッセージを表示する
            replayButton.gameObject.SetActive(true);
            titleButton.gameObject.SetActive(true);
            // ゲームの時間を停止
            Time.timeScale = 0;
        }

        // プレイヤーのライフを表示する
        livesText.text = "Lives: " + lives;

    }

    public void GoBackToTitle()
    {
        // ゲームの時間を再開
        Time.timeScale = 1;
        // シーンをタイトル画面に切り替える
        SceneManager.LoadScene("TitleScene");
    }

    public void ReplayGame()
    {
        // ゲームの時間を再開
        Time.timeScale = 1;
        // シーンをタイトル画面に切り替える
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // ライフ回復
        lives = 3;
        isGameCleared = false;
        isGameOver = false;
    }
}
