using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Enemy"))
        {
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
        
        if (collider2D.gameObject.CompareTag("Totem"))
        {
            StartCoroutine(GetComponent<AnimControllerPlayer>().PlayAnimation("Idle", true));
        }
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("FreeMove"))
        {
            Player.FreeMove(false);
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
