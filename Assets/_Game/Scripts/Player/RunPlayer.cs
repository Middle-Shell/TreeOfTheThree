using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunPlayer : MonoBehaviour
{
    [SerializeField] [Range(10f, 40f)] private float _speed;
    private Rigidbody2D _rbody;
    private Vector2 _moveInput;
    

    void Awake()
    {
        _rbody = GetComponent<Rigidbody2D>();
        
        if(_rbody is null)
            Debug.LogError("Rigidbody is NULL");
    }
    void FixedUpdate()
    {
        _rbody.velocity = new Vector2( _speed, _rbody.velocity.y);
    }
}