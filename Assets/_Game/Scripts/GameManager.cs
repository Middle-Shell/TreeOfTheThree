using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager SingletoneGameManager { get; private set; }

    [SerializeField] private List<GameObject> _levels;
    private GameObject _currentLevel;

    private void Awake()
    {
        if (!SingletoneGameManager)
        {
            SingletoneGameManager = this;
            DontDestroyOnLoad(this);
            
            GenerateLevel(1);//тестовое
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public void GenerateLevel(int levelNumber)
    {
        if (levelNumber > _levels.Count)
        {
            Debug.LogWarning("Out of range! Num > count of levels");
        }
        else if (levelNumber < 0)
        {
            Debug.LogWarning("Out of range! Num < 0");
        }
        else
        {
            if (_currentLevel != null)
            {
                GameObject.Destroy(_currentLevel);
            }

            _currentLevel = Instantiate(_levels[levelNumber], transform);
        }   
    }
}
