using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    [SerializeField] private float _powerMin = 10f;
    [SerializeField] private float _powerMax = 20f;
    [SerializeField] private float _maxAngle = 80f;
    [SerializeField] private float _minAngle = -20f;

    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _pointPosition;
    [SerializeField] private Transform _firePosition;
    private Vector2 _direction;

    private Camera _cam;

    private float _currentPower;
    private bool _isCharging;
    
    [SerializeField] private GameObject _point;
    private GameObject[] _points;
    [SerializeField] private int _numOfPoints;
    [SerializeField] private float _spaceBetweenPoints;
    private Vector2 _bowPosition;
    private Vector2 _mousePosition;
    private bool _isAllowFire;
    private float _angle;
    
    private AnimControllerPlayer _animControllerPlayer;

    private void Awake()
    {
        _cam = Camera.main;
    }
    
    private void Start()
    {
        _animControllerPlayer = GetComponent<AnimControllerPlayer>();
        _points = new GameObject[_numOfPoints];
        for (int i = 0; i < _numOfPoints; i++)
        {
            _points[i] = Instantiate(_point, _firePosition.position, Quaternion.identity);
        }
    }

    private void Update()
    {
        _isAllowFire = true;
        _bowPosition = transform.position;
        _mousePosition = _cam.ScreenToWorldPoint(Input.mousePosition);
        _direction = _mousePosition - _bowPosition;
        _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        if (_angle > _maxAngle || _angle < _minAngle)
        {
            _isCharging = false;
            _isAllowFire = false;
            //_direction = new Vector2(Mathf.Sign(_direction.x), Mathf.Sign(_direction.y));
            ThrowOutPoints();
        }
        _pointPosition.transform.right = _direction;
        
        if (Input.GetMouseButtonDown(0) && _isAllowFire)
        {
            _isCharging = true;
            _currentPower = _powerMin;
            StartCoroutine(_animControllerPlayer.PlayAnimation("run_to_targeting_transition", false));
            StartCoroutine(Charging());
        }
        else if (Input.GetMouseButtonUp(0) && _isCharging)
        {
            StartCoroutine(Fire());
        }
        
        if (_isCharging)
        {
            _currentPower = Mathf.Min(_currentPower + Time.deltaTime/1.5f * (_powerMax - _powerMin), _powerMax);
            for (int i = 0; i < _numOfPoints; i++)
            {
                _points[i].transform.position = PointPosition(i * _spaceBetweenPoints);
            }
        }
    }

    private IEnumerator Charging()
    {
        print("Enter");
        yield return new WaitForSeconds(0.667f);
        print("Wait");
        StartCoroutine(_animControllerPlayer.PlayAnimation("run_with_targeting"));
    }

    private IEnumerator Fire()
    {
        StopCoroutine(Charging());
        _isCharging = false;
        StartCoroutine(_animControllerPlayer.PlayAnimation("run_targeting_throw_run", false));
        yield return new WaitForSeconds(0.3f);
        GameObject newArrow = Instantiate(_prefab, _firePosition.position, _firePosition.rotation);
        newArrow.GetComponent<Arrow>().IsPlayer = true;
        newArrow.GetComponent<Rigidbody2D>().velocity = _pointPosition.transform.right * _currentPower;
        ThrowOutPoints();
        yield return new WaitForSeconds(0.667f);
        StartCoroutine(_animControllerPlayer.PlayAnimation("run"));
    }

    private void ThrowOutPoints()
    {
        for (int i = 0; i < _numOfPoints; i++)
        {
            _points[i].transform.position = PointPosition(-500);
        }
    }

    public void OnDestroy()
    {
        DeleteAllPoints();
    }
    private void DeleteAllPoints()
    {
        for (int i = 0; i < _numOfPoints; i++)
        {
            Destroy(_points[i]);
        }
    }
    private Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2) _firePosition.position + (_direction.normalized * _currentPower * t) +
                           0.5f * Physics2D.gravity * (t * t);
        return position;
    }
}
