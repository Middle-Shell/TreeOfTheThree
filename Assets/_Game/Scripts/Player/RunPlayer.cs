using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class RunPlayer : MonoBehaviour
{
    [Range(10f, 40f)] public const float Speed = 10;
    private Rigidbody2D _rbody;
    private Vector2 _moveInput;
    private bool _isRunning = false;
    private AnimControllerPlayer _animControllerPlayer;



    void Awake()
    {
        _animControllerPlayer = GetComponent<AnimControllerPlayer>();
        _rbody = GetComponent<Rigidbody2D>();
        
        if(_rbody is null)
            Debug.LogError("Rigidbody is NULL");
    }
    void Update()
    {
        _rbody.velocity = new Vector2( Speed, _rbody.velocity.y);
        if (_rbody.velocity.y >= -0.6 && _rbody.velocity.y <= 0 && !_isRunning)
        {
            StartCoroutine(_animControllerPlayer.PlayAnimation("run", true));
            _isRunning = true;
        }
        else if(!(_rbody.velocity.y >= -0.6 && _rbody.velocity.y <= 0)) _isRunning = false;

    }
}