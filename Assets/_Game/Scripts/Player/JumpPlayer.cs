using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayer : MonoBehaviour
{
    private PlayerActions _playerActions;
    private Rigidbody2D _rbody;
    
    private bool _isGrounded;
    private float _gravity;
    
    [SerializeField] [Range(0f, 10f)] private float  FallWeight = 5.0f;
    [SerializeField] [Range(0f, 10f)] private float JumpWeight = 0.5f;
    private float _weight;
    private bool _isFalling;
    
    [SerializeField] [Range(10f, 30f)] private float _jumpForce = 10f;
    
    [SerializeField] private LayerMask _groundLayers;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius = 0.1f;

    void Awake()
    {
        _playerActions = new PlayerActions();
        _rbody = GetComponent<Rigidbody2D>();
        _gravity = Physics.gravity.y;
        
        if(_rbody is null)
            Debug.LogError("Rigidbody is NULL");
    }

    void FixedUpdate()
    {
        //проверяем падает ли игрок
        _isFalling = _rbody.velocity.y <= 0;
        _weight = _isFalling ? FallWeight : JumpWeight;
        
        // Проверяем, коснулся ли игрок земли
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayers);
        
        _rbody.velocity += Vector2.up * _gravity * _weight * Time.deltaTime;
        
        if (_isGrounded && _playerActions.Player_Map.Jump.IsPressed())
        {
            _rbody.velocity = Vector2.up * _jumpForce;
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