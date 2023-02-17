using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunPlayer : MonoBehaviour
{
    [SerializeField] [Range(20f, 40f)] private float _speed;
    [SerializeField] private float _gravity;
    private Rigidbody2D _rbody;
    private Vector2 _moveInput;
    

    void Awake()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _gravity = Physics.gravity.y;
        
        if(_rbody is null)
            Debug.LogError("Rigidbody is NULL");
    }
    void FixedUpdate()
    {
        _rbody.velocity = new Vector2( _speed, _rbody.velocity.y);
        _rbody.velocity += Vector2.up * _gravity * Time.deltaTime;
    }
}