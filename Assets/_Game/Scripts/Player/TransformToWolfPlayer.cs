using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TransformToWolfPlayer : MonoBehaviour
{

    private static bool _isWolf = false;
    private PlayerActions _playerActions;
    private JumpPlayer _jumpController;

    [SerializeField] private GameObject _humanSpriteObject;
    [SerializeField] private GameObject _wolfSpriteObject;
    
    

    public static bool IsWolf
    {
        get => _isWolf;
        private set => _isWolf = value;
    }
    
    private void Awake()
    {
        _playerActions = new PlayerActions();
        //StartCoroutine(Transformation());
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

    void Update()
    {
        if (_playerActions.Player_Map.Transformation.WasPressedThisFrame())
        {
            print(IsWolf);

            IsWolf = !IsWolf;
            print(_jumpController.IsStop);
            _jumpController.IsStop = IsWolf;

            if (_isWolf)
            {
                _wolfSpriteObject.SetActive(true);
                _humanSpriteObject.SetActive(false);
            }
            else
            {
                _humanSpriteObject.SetActive(true);
                _wolfSpriteObject.SetActive(false);
            }
            /*_spriteRenderer.color =
                _isWolf ? Color.red : Color.white; //когда будут арты и т.п. поменять на что то вразумительное*/
        }
    }
    /*IEnumerator Transformation()
    {
        while (true)
        {
            yield return new WaitForSeconds(.1f);
            
        }
    }*/
    
    
    
}
