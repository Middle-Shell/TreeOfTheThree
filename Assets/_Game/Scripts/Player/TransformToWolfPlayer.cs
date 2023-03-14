using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TransformToWolfPlayer : MonoBehaviour
{
    
    private static bool _isWolf;
    private PlayerActions _playerActions;
    private JumpPlayer _jumpController;
    
    [SerializeField] private SpriteRenderer _spriteRenderer;
    

    public static bool IsWolf
    {
        get => _isWolf;
        private set => _isWolf = value;
    }
    
    private void Awake()
    {
        _playerActions = new PlayerActions();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine("Transformation");
        _jumpController = GetComponent<JumpPlayer>();
    }
    
    private void OnEnable()
    {
        _playerActions.Player_Map.Enable();
    }

    private void OnDisable()
    {
        _playerActions.Player_Map.Disable();
        StopAllCoroutines();
    }

    IEnumerator Transformation()
    {
        while (true)
        {
            yield return new WaitForSeconds(.1f);
            if (_playerActions.Player_Map.Transformation.IsPressed())
            {
                print(IsWolf);
                
                IsWolf = !IsWolf;
                print(_jumpController.IsStop);
                _jumpController.IsStop = !IsWolf;

                _spriteRenderer.color =
                    _isWolf ? Color.red : Color.white; //когда будут арты и т.п. поменять на что то вразумительное
            }
        }
    }
    
    
    
}
