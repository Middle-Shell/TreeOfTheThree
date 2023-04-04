using System.Collections;
using System.Collections.Generic;
using Assets._Game.Scripts;
using UnityEngine;

public class BirdController : MonoBehaviour//, IEnableObject
{
    [SerializeField] private bool _isAttack; //будет ли атаковать
    
    [SerializeField] private float _moveSpeed = -3.0f; // Скорость перемещения врага
    //[SerializeField] private float _timeToChangeDirection = 2.0f; // Время до изменения направления движения
    [SerializeField] private float _fireRate = 1.0f; // Частота стрельбы
    [SerializeField] private GameObject _bulletPrefab; // Префаб пули
    [SerializeField] private Transform _firePoint; // Точка, из которой будут вылетать пули
    [SerializeField] private float _bulletForce = 10f;
    [SerializeField] [Range(0f, 10f)] private float _rangeSpawnY = 2f;


    private Rigidbody2D _rb; // Компонент Rigidbody2D врага
    private Vector2 _moveDirection; // Направление движения
    private float _timeSinceDirectionChange; // Время с последнего изменения направления движения
    private float _timeSinceLastShot; // Время с последнего выстрела
    private Transform _player;
    [SerializeField] private bool _isMove;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _moveDirection = Vector2.right;
        transform.position = new Vector3(transform.position.x, transform.position.y + (int)Random.Range(-_rangeSpawnY, _rangeSpawnY), transform.position.z);
    }

    public void OnBecameVisible()
    {
        enabled = true;
    }

    public void OnBecameInvisible()
    {
        print("Invisible");
        enabled = false;
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

    private void Update()
    {
        //перемещаемся туда-сюда
        /*if (Time.time - _timeSinceDirectionChange >= _timeToChangeDirection)
        {
            _moveDirection *= -1;
            _timeSinceDirectionChange = Time.time;
        }*/

        _rb.velocity = _moveDirection * _moveSpeed;
    }

    /*private IEnumerator FixUpdateCoroutine()
    {
        while (true)
        {
            if(!_isMove) yield break;
            print("move");
            _rb.velocity = _moveDirection * _moveSpeed;
            yield return new WaitForSeconds(0.01f);
        }
    }*/

    private void Shoot()
    {
        // Создаем пулю и выстраиваем ее по направлению к игроку
        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
    
        // Рассчитываем время прибытия пули к цели
        float distance = Vector2.Distance(_firePoint.position, _player.transform.position);
        float timeToTarget = distance / _bulletForce;
    
        // Рассчитываем позицию цели в будущем
        Vector3 targetPosition = _player.transform.position + new Vector3(RunPlayer.Speed * timeToTarget, 0f, 0f);
        Vector3 direction = (targetPosition - _firePoint.position).normalized;
    
        // Задаем скорость пули
        bullet.GetComponent<Rigidbody2D>().velocity = direction * _bulletForce;
    
        // Завершаем метод
        _player = null;
    }
}
