using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
	[SerializeField] [Range(10f, 40f)] private float _speed;
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
    void FixedUpdate()
    {
	    _moveInput = _playerActions.Player_Map.Movement.ReadValue<Vector2>();
        
        //задаём скорорсть передвижения, при желании блокируем возможность пережвижения UP/DOWN и тем самым отключаем эффект "плаванья"
        _rbody.velocity = new Vector2(_moveInput.x * _speed, (_blockY ? _rbody.velocity.y : _moveInput.y * _speed));
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
