using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
	[SerializeField] [Range(10f, 40f)] private float _speed;
    [SerializeField] private bool _blockY;
    [SerializeField] [Range(0f, 50f)] private float _fallWeight = 10.0f;
    [SerializeField] [Range(0f, 50f)] private float _ascentWeight = 10.0f;

    private Vector2 _ascentForce;
    private PlayerActions _playerActions;
    private Rigidbody2D _rbody;
    private Vector2 _moveInput;
    private float _gravity;

    public bool BlockY
    {
        set => _blockY = value;
    }

    void Awake()
    {
        _gravity = Physics.gravity.y;
        _playerActions = new PlayerActions();
        _rbody = GetComponent<Rigidbody2D>();
        
        if(_rbody is null)
            Debug.LogError("Rigidbody is NULL"); 
    }
    void FixedUpdate()
    {
	    _moveInput = _playerActions.Player_Map.Movement.ReadValue<Vector2>();
        
        //задаём скорорсть передвижения, при желании блокируем возможность пережвижения UP/DOWN и тем самым отключаем эффект "плаванья"
        _rbody.velocity = new Vector2(_moveInput.x * _speed, (_blockY ? 0 : _moveInput.y * _speed));
        if (!_blockY)
        {
            _ascentForce = Vector2.up * _gravity * _fallWeight * Time.deltaTime;
            if (_moveInput.y > 0)
            {
                _ascentForce = Vector2.up * _gravity * _ascentWeight * Time.deltaTime * -1f;
            }
            else
            {
                _ascentForce = Vector2.up * _gravity * _fallWeight * Time.deltaTime;
            }

            _rbody.velocity += _ascentForce;
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
