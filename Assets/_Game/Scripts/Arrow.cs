using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        print(collision2D.gameObject.tag);
        if (collision2D.gameObject.tag == "Eagle")
        {
            
            Destroy(collision2D.gameObject, .2f);
            PlayerStateEvent.OnPlayerDeath();
        }

        if (collision2D.gameObject.tag == "Enemy")
        {
            Destroy(collision2D.gameObject, .2f);
        }
        Destroy(this.gameObject, 1f);
    }
}