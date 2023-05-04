﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayer : MonoBehaviour
{
    private PlayerActions _playerActions;
    private Rigidbody2D _rbody;

    private bool _isGrounded;
    private float _gravity;
    private bool _isStop;
    private float _weight;
    private bool _isFalling;
    private float _timer;
    private AnimControllerPlayer _animControllerPlayer;

    [SerializeField][Range(0f, 10f)] private float FallWeight = 5.0f;
    [SerializeField][Range(0f, 10f)] private float JumpWeight = 0.5f;
    

    [SerializeField][Range(0f, 60f)] private float _jumpForce = 10f;
    [SerializeField] [Range(0.2f, 5f)] private float _jumpCooldown = 0.5f;

    [SerializeField] private LayerMask _groundLayers;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius = 0.1f;

    private bool _isJumpDown = false;
    

    public bool IsStop
    {
        get => _isStop;
        set => _isStop = value;
    }
    void Awake()
    {
        _playerActions = new PlayerActions();
        _rbody = GetComponent<Rigidbody2D>();
        _animControllerPlayer = GetComponent<AnimControllerPlayer>();
        _gravity = Physics.gravity.y;

        if (_rbody is null)
            Debug.LogError("Rigidbody is NULL");
    }

    void Update()
    {
        if (!_isStop)
        {
            // Проверяем, коснулся ли игрок земли
            _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayers);
            
            if (_isGrounded)
            {
            //0.35f
                //print(_timer);
                _timer += Time.deltaTime;
                if (_playerActions.Player_Map.Jump.IsPressed() && _timer >= _jumpCooldown)
                {
                    _isJumpDown = false;
                    //_rbody.velocity = Vector2.up * _jumpForce;
                    _rbody.AddForce(new Vector2(2f, 1f) * _jumpForce, ForceMode2D.Impulse);
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Master/Character/Character_Jump");
                    _timer = 0f;
                    StartCoroutine(_animControllerPlayer.PlayAnimation("Jump_up", false));
                }

                
            }
            //проверяем падает ли игрок
            _isFalling = _rbody.velocity.y < -0.6;
            _weight = _isFalling ? FallWeight : JumpWeight;
            if (_isFalling && !_isGrounded && !_isJumpDown)
            {
                StartCoroutine(_animControllerPlayer.PlayAnimation("Jump_down", false));
                _isJumpDown = true;
            }
            //TODO пофиксить, слишком много вызовов за раз
            
            _rbody.velocity += Vector2.up * _gravity * _weight * Time.deltaTime;
        }
    }

    private void OnEnable()
    {
        _playerActions.Player_Map.Enable();
    }

    private void OnDisable()
    {
        _playerActions.Player_Map.Disable();
    }

}
