using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformToWolfPlayer : MonoBehaviour
{
    
    private static bool _isWolf;
    private PlayerActions _playerActions;
    
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
                print("Press");
                
                IsWolf = !IsWolf;

                _spriteRenderer.color =
                    _isWolf ? Color.red : Color.green; //когда будут арты и т.п. поменять на что то вразумительное
            }
        }
    }
    
    
    
}
