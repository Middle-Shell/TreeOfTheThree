using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] [Range(1f, 10f)] private float _speed;
    [SerializeField] private bool _blockY;
    private PlayerActions _playerActions;
    private Rigidbody2D _rbody;
    private Vector2 _moveInput;

    void Awake()
    {
        _playerActions = new PlayerActions();

        _rbody = GetComponent<Rigidbody2D>();
        if(_rbody is null)
            Debug.LogError("Rigidbody is NULL");
    }

    private void OnEnable()
    {
        _playerActions.Player_Map.Enable();
    }

    private void OnDisable()
    {
        _playerActions.Player_Map.Disable();
    }

    void FixedUpdate()
    {
        _moveInput = _playerActions.Player_Map.Movement.ReadValue<Vector2>();
        if (_blockY) _moveInput.y = 0f;
        _rbody.velocity = _moveInput * _speed;
    }
}
