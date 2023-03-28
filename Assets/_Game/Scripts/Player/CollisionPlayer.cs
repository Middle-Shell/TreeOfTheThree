using System.Collections;
using System.Collections.Generic;
using Assets._Game.Scripts.Enemy;
using UnityEngine;

public class CollisionPlayer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        collider2D.gameObject.GetComponent<EnableObject>()?.Enable();
        if (collider2D.gameObject.CompareTag("Enemy"))
        {
            print("Hit!");
            PlayerStateEvent.OnPlayerDeath();
        }

        if (collider2D.gameObject.CompareTag("Waystone"))
        {
            GameManager.SingletoneGameManager.GenerateLevel(GameManager.SingletoneGameManager.CurrentLevelIndex + 1, collider2D.transform.position.x);
        }
    }

    void OnTriggerExit(Collider2D collider2D)
    {
        collider2D.gameObject.GetComponent<EnableObject>()?.Disable();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(("Swamp")))
        {
            PlayerStateEvent.OnPlayerDeath();
        }
    }
}
