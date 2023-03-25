using System.Collections;
using UnityEditor;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _item;
    [SerializeField] private GameObject _roof;
    [SerializeField] private GameObject _floor;
    [Space(30)]
    [Range(1, 100)]
    [SerializeField] private int _levelDistance;
    [Range(0, 100)]
    [SerializeField] private int _safeEnemySpawnDistance;
    [Range(0, 100)]
    [SerializeField] private int _safeEnemyEndDistance;
    [Range(0, 100)]
    [SerializeField] private int _safeItemSpawnDistance;
    [Range(0, 100)]
    [SerializeField] private int _safeItemEndDistance;

    [Range(0, 100)]
    [SerializeField] private int _countEnemy;
    [Range(0, 100)]
    [SerializeField] private int _countItem;
    [Space(10)]
    [Range(1, 10)]
    [SerializeField] private int _distanceBetweenEnemy;
    [Range(1, 10)]
    [SerializeField] private int _distanceBetweenItem;

    [Space(30)]
    [SerializeField] private bool _useRandomGenerator;
    [Space(30)]
    [Range(1, 10)]
    [SerializeField] private int _minDistanceBetweenEnemy;
    [Range(1, 10)]
    [SerializeField] private int _mindistanceBetweenItem;
    [Range(1, 10)]
    [SerializeField] private int _maxDistanceBetweenEnemy;
    [Range(1, 10)]
    [SerializeField] private int _maxdistanceBetweenItem;


    private void OnValidate()
    {
        
    }

    void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        _roof.transform.position = new Vector2(_levelDistance/2, _roof.transform.position.y);
        _floor.transform.position = new Vector2(_levelDistance / 2, _floor.transform.position.y);

        _roof.transform.localScale = new Vector3(_levelDistance, 1, 1);
        _floor.transform.localScale = new Vector3(_levelDistance, 1, 1);

        if (!_useRandomGenerator)
        {
            int temp = _levelDistance - _safeEnemyEndDistance - _safeEnemyEndDistance;
            temp = temp / _distanceBetweenEnemy;

            if (temp >= _countEnemy)
            {
                temp = _countEnemy;
            }
            else
            {
                Debug.LogWarning(" оличество врагов превысило максимальное значение!");
            }

            Vector2 tempVector = new Vector2(_safeEnemySpawnDistance, 1);

            for (int i = 0; i < temp; i++)
            {
                Instantiate(_enemy, tempVector, Quaternion.identity, transform);

                tempVector.x += _distanceBetweenEnemy;
            }



            temp = _levelDistance - _safeItemSpawnDistance - _safeItemEndDistance;
            temp = temp / _distanceBetweenItem;

            if (temp >= _countItem)
            {
                temp = _countItem;
            }
            else
            {
                Debug.LogWarning(" оличество предметов превысило максимальное значение!");
            }

            tempVector = new Vector2(_safeItemSpawnDistance, -1);

            for (int i = 0; i < temp; i++)
            {
                Instantiate(_item, tempVector, Quaternion.identity, transform);

                tempVector.x += _distanceBetweenItem;
            }
        }
        else
        {
            Vector2 tempVector = new Vector2(_safeEnemySpawnDistance, 1);

            for (int i = 0; i < _countEnemy; i++)
            {
                Instantiate(_enemy, tempVector, Quaternion.identity, transform);

                tempVector.x += Random.Range(_minDistanceBetweenEnemy, _maxDistanceBetweenEnemy);
                if (tempVector.x > _levelDistance - _safeEnemyEndDistance)
                {
                    break;
                }
            }

            tempVector = new Vector2(_safeItemSpawnDistance, -1);

            for (int i = 0; i < _countItem; i++)
            {
                Instantiate(_item, tempVector, Quaternion.identity, transform);

                tempVector.x += Random.Range(_mindistanceBetweenItem, _maxdistanceBetweenItem);
                if (tempVector.x > _levelDistance - _safeItemEndDistance)
                {
                    break;
                }
            }
        }
    }
}
