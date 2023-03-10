using UnityEngine;

public class LevelSetting : MonoBehaviour
{
    [SerializeField] private GameObject _waystone; // stone/totem at the end of the level
    [SerializeField] private GameObject _player; 
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _item;
    [SerializeField] private GameObject _obstacle;
    [SerializeField] private GameObject _roof;
    [SerializeField] private GameObject _floor;
    [SerializeField] private SpriteRenderer _background;
    [Space(30)]
    [Range(1, 10000)]
    [SerializeField] private int _levelDistance;
    [Range(0, 1000)]
    [SerializeField] private int _safeSpawnDistance;
    [Range(0, 1000)]
    [SerializeField] private int _safeEndDistance;
    [Range(1, 100)]
    [SerializeField] private int _safeWidthObstacle;
    [Range(1, 100)]
    [SerializeField] private int _safeWidthEnemy;
    [Range(0, 100)]
    [SerializeField] private int _enemyCount;
    [Range(0, 100)]
    [SerializeField] private int _obstacleCount;
    [Range(0, 100)]
    [SerializeField] private int _itemCount;

    bool[] freeCoordinates = null;
    void Start()
    {
        freeCoordinates = new bool[_levelDistance];

        GenerateLevel();
    }

    private void GenerateLevel()
    {
        for (int i = 0; i < freeCoordinates.Length; i++)
        {
            freeCoordinates[i] = true;
        }
        _roof.transform.position = new Vector2(_levelDistance / 2, _roof.transform.position.y);
        _floor.transform.position = new Vector2(_levelDistance / 2, _floor.transform.position.y);

        _roof.transform.localScale = new Vector3(_levelDistance, 1, 1);
        _floor.transform.localScale = new Vector3(_levelDistance, 1, 1);

        _background.size = new Vector2(_levelDistance, _background.size.y);
        _background.transform.position = new Vector2(_levelDistance / 2, _background.transform.position.y);

        _waystone.transform.position = new Vector2(_levelDistance, _roof.transform.position.y);
        _player.transform.position = Vector2.zero;

        GenerateObstacles();
        GenerateEnemys();
        GenerateItems();
    }

    private void GenerateObstacles()
    {
        int temp = 0;
        bool isFree = true;
        bool canPlace = false;
        int possibleCount = 0;

        for (int i = 0; i < _obstacleCount;)
        {
            temp = Random.Range(_safeSpawnDistance + _safeWidthObstacle, freeCoordinates.Length - _safeEndDistance - _safeWidthObstacle);

            if (freeCoordinates[temp] == true)
            {
                for (int a = temp - _safeWidthObstacle; a < temp + _safeWidthObstacle; a++)
                {
                    if (freeCoordinates[a] == false)
                    {
                        isFree = false;
                        break;
                    }
                }

                if (isFree)
                {
                    Vector2 tempVector = new Vector2(temp, _obstacle.transform.position.y);

                    GameObject tempGM = Instantiate(_obstacle, tempVector, Quaternion.identity, transform);

                    tempGM.SetActive(true);

                    i++;

                    for (int a = temp - _safeWidthObstacle; a < temp + _safeWidthObstacle; a++)
                    {
                        freeCoordinates[a] = false;
                    }
                }
                else
                {
                    isFree = true;
                }
            }

            for (int a = _safeSpawnDistance + _safeWidthObstacle; a < freeCoordinates.Length - _safeEndDistance - _safeWidthObstacle; a ++) 
            {
                for (int b = temp - _safeEndDistance; b < temp + _safeWidthObstacle; b++)
                {
                    if (freeCoordinates[a] == false)
                    {
                        canPlace = false;
                        break;
                    }
                }

                if (canPlace == true)
                {
                    possibleCount++;
                }
                else
                {
                    canPlace = true;
                }
            }

            if (possibleCount == 0)
            {
                Debug.LogWarning(" оличество преп€тствий превысило максимальное возможное значение! √енераци€ остановлена.  оличество преп€тствий: " + i);
                break;
            }

            possibleCount = 0;
        }
    }

    private void GenerateEnemys()
    {
        int temp = 0;
        bool isFree = true;
        bool canPlace = false;
        int possibleCount = 0;

        for (int i = 0; i < _enemyCount;)
        {
            temp = Random.Range(_safeSpawnDistance + _safeWidthEnemy, freeCoordinates.Length - _safeEndDistance - _safeWidthEnemy);

            if (freeCoordinates[temp] == true)
            {
                for (int a = temp - _safeWidthEnemy; a < temp + _safeWidthEnemy; a++)
                {
                    if (freeCoordinates[a] == false)
                    {
                        isFree = false;
                        break;
                    }
                }

                if (isFree)
                {
                    Vector2 tempVector = new Vector2(temp, _enemy.transform.position.y);

                    GameObject tempGM = Instantiate(_enemy, tempVector, Quaternion.identity, transform);

                    tempGM.SetActive(true);

                    i++;

                    for (int a = temp - _safeWidthEnemy; a < temp + _safeWidthEnemy; a++)
                    {
                        freeCoordinates[a] = false;
                    }
                }
                else
                {
                    isFree = true;
                }
            }

            for (int a = _safeSpawnDistance + _safeWidthEnemy; a < freeCoordinates.Length - _safeEndDistance - _safeWidthEnemy; a ++)
            {
                for (int b = temp - _safeEndDistance; b < temp + _safeWidthEnemy; b++)
                {
                    if (freeCoordinates[a] == false)
                    {
                        canPlace = false;
                        break;
                    }
                }

                if (canPlace == true)
                {
                    possibleCount++;
                }
                else
                {
                    canPlace = true;
                }
            }

            if (possibleCount == 0)
            {
                Debug.LogWarning(" оличество врагов превысило максимальное возможное значение! √енераци€ остановлена.  оличество врагов: " + i);
                break;
            }

            possibleCount = 0;
        }
    }

    private void GenerateItems()
    {
        int temp;

        temp = Random.Range(_safeSpawnDistance , freeCoordinates.Length - _safeEndDistance);

        for (int i = 0; i < _itemCount; i++)
        {
            Vector2 tempVector = new Vector2(temp, _item.transform.position.y);

            GameObject tempGM = Instantiate(_item, tempVector, Quaternion.identity, transform);
            tempGM.SetActive(true);
        }
    }
}
