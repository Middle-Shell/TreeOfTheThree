using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager SingletoneGameManager { get; private set; }

    [SerializeField] private List<GameObject> _levels = null;
    [SerializeField] private UiManager _uiManager = null;
    private GameObject _currentLevel = null;

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
    private void Start()
    {
        _uiManager.ShowMenu();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Y))
        {
            SaveManager.SaveBestiary(7);
        }

        if (Input.GetKey(KeyCode.T))
        {
            SaveManager.SaveBestiary(0);
        }

        if (Input.GetKey(KeyCode.Escape) && _currentLevel != null)
        {
            _uiManager.ShowInGameMenu();
        }
    }

    public void GenerateLevel(int levelNumber)
    {
        if (levelNumber > _levels.Count)
        {
            Debug.LogWarning("Такого уровня не существует!");
        }
        else if (levelNumber < 0)
        {
            Debug.LogWarning("Номера уровня строго неотрицательны!");
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

    public void PlayLevel(bool levelContinue)
    {
        _uiManager.HideMenu();
        _uiManager.HideBestiary();
        _uiManager.HideInGameMenu();

        if (levelContinue)
        {
            GenerateLevel(SaveManager.LoadCurrentLevel());
        }
        else
        {
            GenerateLevel(0);
        }
    }

    public void CloseLevel()
    {
        _uiManager.ShowMenu();
        _uiManager.HideBestiary();
        _uiManager.HideInGameMenu();

        GameObject.Destroy(_currentLevel);
        _currentLevel = null;
    }

    public void Exit()
    {
        Application.Quit();
    }
}