using System.Collections;
using System.Collections.Generic;
using Assets._Game.Scripts;
using UnityEngine;

public class FishController : MonoBehaviour//, IEnableObject
{
    [SerializeField] private float _speed = 5f;
    
    private Rigidbody2D _rigidbody2D;

    private Vector2 _movement;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void OnBecameVisible()
    {
        enabled = true;
        print("Visible");
    }

    public void OnBecameInvisible()
    {
        print("Invisible");
        enabled = false;
    }
    
    void FixedUpdate()
    {
        _movement = new Vector2(-1, 0);
        _rigidbody2D.velocity = _movement * _speed;
    }
}
