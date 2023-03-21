using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] private bool _isAttack; //будет ли атаковать
    
    [SerializeField] private float _moveSpeed = -3.0f; // Скорость перемещения врага
    [SerializeField] private float _timeToChangeDirection = 2.0f; // Время до изменения направления движения
    [SerializeField] private float _fireRate = 1.0f; // Частота стрельбы
    [SerializeField] private GameObject _bulletPrefab; // Префаб пули
    [SerializeField] private Transform _firePoint; // Точка, из которой будут вылетать пули
    [SerializeField] private float _bulletForce = 10f;

    private Rigidbody2D _rb; // Компонент Rigidbody2D врага
    private Vector2 _moveDirection; // Направление движения
    private float _timeSinceDirectionChange; // Время с последнего изменения направления движения
    private float _timeSinceLastShot; // Время с последнего выстрела
    private Transform _player;

    private void Start()
    {
        
        _rb = GetComponent<Rigidbody2D>();
        _moveDirection = Vector2.right;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && _isAttack)
        {
            _player = collision.gameObject.transform;
            if (Time.time - _timeSinceLastShot >= 1 / _fireRate)
            {
                Shoot();
                _timeSinceLastShot = Time.time;
            }
        }
    }

    private void FixedUpdate()
    {
        //перемещаемся туда-сюда
        /*if (Time.time - _timeSinceDirectionChange >= _timeToChangeDirection)
        {
            _moveDirection *= -1;
            _timeSinceDirectionChange = Time.time;
        }*/

        _rb.velocity = _moveDirection * _moveSpeed;
    }

    private void Shoot()
    {
        // Создаем пулю и выстраиваем ее по направлению к игроку
        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
        Vector2 direction = (_player.transform.position - _firePoint.position).normalized;
        bullet.GetComponent<Rigidbody2D>().velocity = direction * _bulletForce;
        _player = null;
    }
}
