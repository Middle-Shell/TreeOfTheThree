using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayer : MonoBehaviour
{
    private PlayerActions _playerActions;
    private Rigidbody2D _rbody;
    private bool _isGrounded;
    
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask _groundLayers;
    [SerializeField] [Range(10f, 30f)] private float jumpForce = 10f;

    void Awake()
    {
        _playerActions = new PlayerActions();
        _rbody = GetComponent<Rigidbody2D>();
        
        if(_rbody is null)
            Debug.LogError("Rigidbody is NULL");
    }

    void FixedUpdate()
    {
        // Проверяем, коснулся ли игрок земли
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, groundCheckRadius, _groundLayers);
        
        if (_isGrounded && _playerActions.Player_Map.Jump.IsPressed())
        {
            _rbody.velocity = Vector2.up * jumpForce;
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