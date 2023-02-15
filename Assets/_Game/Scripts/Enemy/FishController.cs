using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    
    private Rigidbody2D _rigidbody2D;

    private Vector2 _movement;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        _movement = new Vector2(-1, 0);
        _rigidbody2D.velocity = _movement * _speed;
    }
}
