using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    [SerializeField] private float _powerMin = 10f;
    [SerializeField] private float _powerMax = 20f;

    [SerializeField] private GameObject _prefab;
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

    private void Awake()
    {
        _cam = Camera.main;
    }
    
    private void Start()
    {
        _points = new GameObject[_numOfPoints];
        for (int i = 0; i < _numOfPoints; i++)
        {
            _points[i] = Instantiate(_point, _firePosition.position, Quaternion.identity);
        }
    }

    private void FixedUpdate()
    {
        _bowPosition = transform.position;
        _mousePosition = _cam.ScreenToWorldPoint(Input.mousePosition);
        _direction = _mousePosition - _bowPosition;
        transform.right = _direction;
        if (Input.GetMouseButtonDown(0))
        {
            _isCharging = true;
            _currentPower = _powerMin;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _isCharging = false;
            GameObject newArrow = Instantiate(_prefab, _firePosition.position, _firePosition.rotation);
            newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * _currentPower;
            for (int i = 0; i < _numOfPoints; i++)
            {
                _points[i].transform.position = PointPosition(-500);
            }
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
    private Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2) _firePosition.position + (_direction.normalized * _currentPower * t) +
                           0.5f * Physics2D.gravity * (t * t);
        return position;
    }
}
