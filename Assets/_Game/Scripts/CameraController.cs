using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance  { get; private set; }
    [SerializeField] private bool _runOver;
    
    [Header("Parameters")]
    [SerializeField] private Transform _player;
    [SerializeField] [Range(0f, 10f)] private float _movingSpeed = 3f;
    [SerializeField] [Range(0f, 10f)] private float _movingSpeedRunOver = 0.5f;
    [SerializeField] private Vector3 _offsetXYZ = new (4f, 0f, -500f);//-500 по Z что бы не было спрайтов уходящих за камеру
    [SerializeField] private float _limitYDown;
    [SerializeField] private float _limitYUp;

    private Vector3 _target;

    public Transform Player
    {
        get => _player;
        set => _player = value;
    }
    
    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (Player)
        {
            _target = Player.position + _offsetXYZ;
            
            if (_target.y > _limitYUp)
            {
                _target.y = _limitYUp;
            }

            if (_target.y < -_limitYDown)
            {
                _target.y = -_limitYDown;
            }
            if(_runOver)
                transform.Translate(new Vector3(_movingSpeedRunOver, 0f, 0f));
            else
                transform.position = Vector3.Lerp(transform.position, _target, _movingSpeed * Time.deltaTime);
            
        }
    }
}
