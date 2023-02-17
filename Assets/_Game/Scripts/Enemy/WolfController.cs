using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : MonoBehaviour
{
    private CircleCollider2D _circleCollider2D;

    [SerializeField] private float _rangeDetect = 5f;
    // Start is called before the first frame update
    void Start()
    {
        _circleCollider2D = gameObject.AddComponent<CircleCollider2D>();
        _circleCollider2D.isTrigger = true;
        _circleCollider2D.radius = _rangeDetect;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine("CheckStatePlayer");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
        }
    }

    IEnumerator CheckStatePlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(.1f);
            if (!TransformToWolfPlayer.IsWolf)
            {
                print("типа сожрал");
                PlayerStateEvent.OnPlayerDeath();
            }
        }
    }
}
