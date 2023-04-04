using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance  { get; private set; }
    
    [Header("Parameters")]
    [SerializeField] private Transform _player;
    [SerializeField] [Range(0.5f, 10f)] private readonly float movingSpeed = 5f;
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

            transform.position = Vector3.Lerp(transform.position, _target, movingSpeed * Time.deltaTime);
        }
    }
}
