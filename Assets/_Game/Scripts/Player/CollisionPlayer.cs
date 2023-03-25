using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("Hit!");
            PlayerStateEvent.OnPlayerDeath();
        }

        if (collision.gameObject.CompareTag("Waystone"))
        {
            GameManager.SingletoneGameManager.GenerateLevel(GameManager.SingletoneGameManager.CurrentLevelIndex + 1, collision.transform.position.x);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(("Swamp")))
        {
            PlayerStateEvent.OnPlayerDeath();
        }
    }
}
