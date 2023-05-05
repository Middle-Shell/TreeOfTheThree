using System.Collections.Generic;
using UnityEngine;

public class LevelSetting : MonoBehaviour
{
    [SerializeField] private GameObject _waystone = null; // stone/totem at the end of the level
    [SerializeField] private GameObject _player = null; 
    [SerializeField] private List<GameObject> _enemy = new List<GameObject>();
    [SerializeField] private List<GameObject> _item = new List<GameObject>();
    [SerializeField] private List<GameObject> _obstacle = new List<GameObject>();
    [SerializeField] private GameObject _roof = null;
    [SerializeField] private GameObject _floor = null;
    [SerializeField] private SpriteRenderer _background = null;
    [Space(30)]
    [Range(1, 10000)]
    [SerializeField] private int _levelDistance = 0;
    [Range(0, 1000)]
    [SerializeField] private int _safeSpawnDistance = 0;
    [Range(0, 1000)]
    [SerializeField] private int _safeEndDistance = 0;
    [Range(1, 100)]
    [SerializeField] private List<int> _safeWidthObstacle = new List<int>();
    [Range(1, 100)]
    [SerializeField] private List<int> _safeWidthEnemy = new List<int>();
    [Range(0, 100)]
    [SerializeField] private List<int> _enemyCount = new List<int>();
    [Range(0, 100)]
    [SerializeField] private List<int> _obstacleCount = new List<int>();
    [Range(0, 100)]
    [SerializeField] private List<int> _itemCount = new List<int>();

    [SerializeField] private static Vector2 _startPoint = Vector2.zero;
    
    bool[] freeCoordinates = null;
    void Start()
    {
        freeCoordinates = new bool[_levelDistance];
    
        GenerateLevel();
    }

    public static Vector2 StartPoint
    {
        set => _startPoint = value;
    }
    private void GenerateLevel()
    {
        for (int i = 0; i < freeCoordinates.Length; i++)
        {
            freeCoordinates[i] = true;
        }
        _roof.transform.position = _startPoint + new Vector2(_levelDistance / 2, _roof.transform.position.y);
        _floor.transform.position = _startPoint + new Vector2(_levelDistance / 2, _floor.transform.position.y);

        _roof.transform.localScale = new Vector3(_levelDistance, 1, 1);
        _floor.transform.localScale = new Vector3(_levelDistance, 1, 1);

        _background.size = new Vector2(_levelDistance+30f, _background.size.y);
        _background.transform.position = _startPoint + new Vector2(_levelDistance / 2, _background.transform.position.y);

        _waystone.transform.position = _startPoint +  new Vector2(_levelDistance, _floor.transform.position.y);
        if(Player.IsPlayerNotNull)
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

        for (int g = 0; g < _obstacle.Count; g++)
        {
            for (int i = 0; i < _obstacleCount[g];)
            {
                temp = Random.Range(_safeSpawnDistance + _safeWidthObstacle[g], freeCoordinates.Length - _safeEndDistance - _safeWidthObstacle[g]);

                if (freeCoordinates[temp] == true)
                {
                    for (int a = temp - _safeWidthObstacle[g]; a < temp + _safeWidthObstacle[g]; a++)
                    {
                        if (freeCoordinates[a] == false)
                        {
                            isFree = false;
                            break;
                        }
                    }

                    if (isFree)
                    {
                        Vector2 tempVector = new Vector2(temp, _obstacle[g].transform.position.y);

                        GameObject tempGM = Instantiate(_obstacle[g], _startPoint + tempVector, Quaternion.identity, transform);

                        tempGM.SetActive(true);

                        i++;

                        for (int a = temp - _safeWidthObstacle[g]; a < temp + _safeWidthObstacle[g]; a++)
                        {
                            freeCoordinates[a] = false;
                        }
                    }
                    else
                    {
                        isFree = true;
                    }
                }

                for (int a = _safeSpawnDistance + _safeWidthObstacle[g]; a < freeCoordinates.Length - _safeEndDistance - _safeWidthObstacle[g]; a++)
                {
                    for (int b = temp - _safeEndDistance; b < temp + _safeWidthObstacle[g]; b++)
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
                    Debug.LogWarning("���������� ����������� ��������� ������������ ��������� ��������! ��������� �����������. ���������� �����������: " + i);
                    break;
                }

                possibleCount = 0;
            }
        }
    }

    private void GenerateEnemys()
    {
        int temp = 0;
        bool isFree = true;
        bool canPlace = false;
        int possibleCount = 0;

        for (int g = 0; g < _enemy.Count; g++)
        {
            for (int i = 0; i < _enemyCount[g];)
            {
                temp = Random.Range(_safeSpawnDistance + _safeWidthEnemy[g], freeCoordinates.Length - _safeEndDistance - _safeWidthEnemy[g]);

                if (freeCoordinates[temp] == true)
                {
                    for (int a = temp - _safeWidthEnemy[g]; a < temp + _safeWidthEnemy[g]; a++)
                    {
                        if (freeCoordinates[a] == false)
                        {
                            isFree = false;
                            break;
                        }
                    }

                    if (isFree)
                    {
                        Vector2 tempVector = new Vector2(temp, _enemy[g].transform.position.y);

                        GameObject tempGM = Instantiate(_enemy[g], _startPoint + tempVector, Quaternion.identity, transform);

                        tempGM.SetActive(true);

                        i++;

                        for (int a = temp - _safeWidthEnemy[g]; a < temp + _safeWidthEnemy[g]; a++)
                        {
                            freeCoordinates[a] = false;
                        }
                    }
                    else
                    {
                        isFree = true;
                    }
                }

                for (int a = _safeSpawnDistance + _safeWidthEnemy[g]; a < freeCoordinates.Length - _safeEndDistance - _safeWidthEnemy[g]; a++)
                {
                    for (int b = temp - _safeEndDistance; b < temp + _safeWidthEnemy[g]; b++)
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
                    Debug.LogWarning("���������� ������ ��������� ������������ ��������� ��������! ��������� �����������. ���������� ������: " + i);
                    break;
                }

                possibleCount = 0;
            }
        }
    }

    private void GenerateItems()
    {
        int temp;
        
        for (int g = 0; g < _item.Count; g++)
        {
            for (int i = 0; i < _itemCount[g]; i++)
            {
                temp = Random.Range(_safeSpawnDistance , freeCoordinates.Length - _safeEndDistance);

                Vector2 tempVector = new Vector2(temp, _item[g].transform.position.y);

                GameObject tempGM = Instantiate(_item[g], _startPoint + tempVector, Quaternion.identity, transform);
                tempGM.SetActive(true);
            }
        }
    }
}
