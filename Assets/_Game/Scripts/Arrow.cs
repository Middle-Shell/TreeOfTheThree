using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        switch (collision2D.gameObject.tag)
        { 
            case "Eagle":
                PlayerStateEvent.OnPlayerDeath();
                Destroy(collision2D.gameObject, .2f);
                return;
            
            case "Kite":
                Destroy(collision2D.gameObject, .2f);
                return;
            
            case "Player":
                PlayerStateEvent.OnPlayerDeath();
                Destroy(collision2D.gameObject, .2f);
                return;

        }
        Destroy(this.gameObject, .2f);
    }
}