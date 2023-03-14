using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager SingletoneGameManager { get; private set; }

    [SerializeField] private List<GameObject> _levels;
    private GameObject _currentLevel;
    private int _currentIndexLevel;

    public int CurrentLevel
    {
        get => _currentIndexLevel;
        set => _currentIndexLevel = value;
    }
    private void Awake()
    {
        if (!SingletoneGameManager)
        {
            SingletoneGameManager = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    void Start()
    {
        GenerateLevel(1);
    }

    public void GenerateLevel(int levelNumber, Transform startPosition = null)
    {
        CurrentLevel = levelNumber;
        print(CurrentLevel);
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
                print("destroy");
            }

            _currentLevel = Instantiate(_levels[levelNumber], (startPosition == null ? transform : startPosition));
            print(_currentLevel);
        }   
    }
    
    public void ReloadScene()//для тестов, потом удалить
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GenerateLevel(CurrentLevel);
    }
}
