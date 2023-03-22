using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager SingletoneGameManager { get; private set; }

    [SerializeField] private List<GameObject> _levels;
    private GameObject _currentLevel;
    private int _currentIndexLevel;

    public int CurrentLevelIndex
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
        GenerateLevel(2);
    }

    public void GenerateLevel(int levelNumber, Transform startPosition = null)
    {
        CurrentLevelIndex = levelNumber;
        print(CurrentLevelIndex);
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
                Destroy(_currentLevel);
                print("destroy");
            }

            _currentLevel = Instantiate(_levels[levelNumber]);
            StartCoroutine(ShiftTransform(startPosition.position.x));
            print(_currentLevel);
            
        }   
    }

    IEnumerator ShiftTransform(float shift)
    {
        yield return new WaitForSeconds(.01f);
        _currentLevel.transform.position =
            new Vector3(_currentLevel.transform.position.x + shift, 0f);
    }
    
    public void ReloadScene()//для тестов, потом удалить
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GenerateLevel(CurrentLevelIndex);
    }
}
