using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public bool IsPlayer { get; set; }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        switch (collision2D.gameObject.tag)
        { 
            case "Eagle":
                PlayerStateEvent.OnPlayerDeath();
                Destroy(collision2D.gameObject, .2f);
                break;
            
            case "Kite":
                Destroy(collision2D.gameObject, .2f);
                break;
            
            case "Player":
                if (IsPlayer)
                    break;
                PlayerStateEvent.OnPlayerDeath();
                Destroy(collision2D.gameObject, .2f);
                break;
        }
        Destroy(this.gameObject, .1f);
    }
}