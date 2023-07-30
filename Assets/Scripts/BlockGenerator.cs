using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    // ブロックのプレファブをInspectorから指定します
    public GameObject blockPrefab;
    // ブロックを並べる行数
    public int rows = 5;
    // ブロックを並べる列数
    public int cols = 8;
    // ブロック間のスペース
    public Vector2 spaceBetween = new Vector2(2.0f, 0.7f);

    void Start()
    {
        // 初期位置はBlock自身の位置とします
        Vector2 startPos = this.transform.position;
        // ブロック全体が画面中央に配置されるように開始位置を調整
        startPos -= new Vector2(((cols - 1) * spaceBetween.x) / 2, ((rows - 1) * spaceBetween.y) / 2);

        // 行と列の数だけループを回してブロックをインスタンス化します
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                // 生成するブロックの位置を計算します。spaceBetween.xとspaceBetween.yを使用します。
                Vector2 spawnPos = startPos + new Vector2(j * spaceBetween.x, -i * spaceBetween.y);
                Instantiate(blockPrefab, spawnPos, Quaternion.identity);
                // ブロックが生成されるたびにカウントを増やします
                GameManager.blockCount++;
            }
        }
    }
}
