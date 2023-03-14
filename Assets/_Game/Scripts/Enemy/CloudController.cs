using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _whiteCloud;
    [SerializeField] private SpriteRenderer _blackCloud;
    [SerializeField] private float _duration = 5.0f;
    
    [SerializeField] private bool _isAttack; //будет ли атаковать
    
    [SerializeField] private float _moveSpeed = 3.0f; // Скорость перемещения врага
    [SerializeField] private float _fireRate = 3.0f; // Частота стрельбы
    [SerializeField] private GameObject _bulletPrefab; // Префаб пули
    [SerializeField] private Transform _firePoint; // Точка, из которой будут вылетать пули
    [SerializeField] private LayerMask _layerMask;

    private Rigidbody2D _rb; // Компонент Rigidbody2D врага
    private Vector2 _moveDirection; // Направление движения
    private float _timeSinceLastShot; // Время с последнего выстрела
    private GameObject _bullet;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _moveDirection = Vector2.left;
    }

    private void FixedUpdate()
    {
        _rb.velocity = _moveDirection * _moveSpeed;
        if ((_isAttack) && (Time.time - _timeSinceLastShot >= _fireRate))
        {
            if(_bullet == null)
                Shoot();
            _timeSinceLastShot = Time.time;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((_layerMask & (1<< other.gameObject.layer)) != 0)
        {
            GetComponent<Collider2D>().isTrigger = true;
            StartCoroutine(ChangeCloudToWhite());
        }
    }

    private void Shoot()
    {
        Destroy(Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity), 1f);
    }

    private IEnumerator  ChangeCloudToWhite()
    {
        float t = 0.0f;
        Color whiteColor = _whiteCloud.color;
        Color blackColor = _blackCloud.color;
        while (true)
        {
            //Постепенно меняем альфа канал спрайтов, скрывая один и раскрывая второй
            var a = Mathf.Lerp(_whiteCloud.color.a, 1, t);
            whiteColor.a = a;
            _whiteCloud.color = whiteColor;
            _blackCloud.color = blackColor - whiteColor;

            // Увеличиваем время на delta time, чтобы достичь нужного промежуточного спрайта через duration секунд
            t += Time.deltaTime / _duration;

            // Если достигли конца, то выходим из цикла
            if (t >= 1.0f)
            {
                _isAttack = false;
                break;
            }

            // Ждем один кадр
            yield return null;
        }
    }
}
