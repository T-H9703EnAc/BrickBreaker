using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ball")
        {
            // ブロックが破壊されるたびにカウントを減らします
            GameManager.blockCount--;
            Destroy(gameObject);
        }
    }
}
