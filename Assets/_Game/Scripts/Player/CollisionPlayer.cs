using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Enemy"))
        {
            print(collider2D.gameObject.name + " Hit!");
            PlayerStateEvent.OnPlayerDeath();
        }

        if (collider2D.gameObject.CompareTag("Waystone"))
        {
            GameManager.SingletoneGameManager.GenerateLevel(SaveManager.LoadCurrentLevel() + 1, collider2D.transform.position.x-5);
            Player.FreeMove(false);
        }

        if (collider2D.gameObject.CompareTag("FreeMove"))
        {
            Player.FreeMove(true);
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
