using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager SingletoneGameManager { get; private set; }

[SerializeField] private int _startLevelNum = 0;
    [SerializeField] private List<GameObject> _levels = null;
    [SerializeField] private UiManager _uiManager = null;
    private GameObject _currentLevel = null;


    public int CurrentLevelIndex { get; private set; }
    public int CurrentBestNum { get; set; }
    public UiManager UiManager => _uiManager;

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
        PlayerStateEvent.PlayerCollectPotEvent += SetNumPot;
    }

    private void SetNumPot()
    {
        CurrentBestNum++;
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

    public void GenerateLevel(int levelNumber, float startPositionX = 0)
    {
        CurrentLevelIndex = levelNumber;
        SaveProgress(CurrentLevelIndex, CurrentBestNum);
        
        
        if (levelNumber > _levels.Count)
        {
            Debug.LogWarning("���������� ������!");
        }
        else if (levelNumber < 0)
        {
            Debug.LogWarning("������������� ������� ���!");
        }
        else
        {
            if (_currentLevel != null)
            {
                Destroy(_currentLevel);
            }

            if (CurrentLevelIndex % 3 == 0 && CurrentLevelIndex != 0)
            {
                PlayerStateEvent.OnFinishMilestone();
                Player.DeletePlayer(); 
                startPositionX = 0;
            }

            if (CurrentLevelIndex < 3) //в билде не требуется т.к. игра начинается с 0 и RunOver по умолчанию true
                CameraController.Instance.RunOver = true;

            LevelSetting.StartPoint = new Vector2(startPositionX, 0);
            var cam = Camera.main;
            cam.transform.position = new Vector3(startPositionX, 0, cam.transform.position.z);
            _currentLevel = Instantiate(_levels[levelNumber]);
            
            //StartCoroutine(ShiftTransform(startPositionX));
        }   
    }

    private void SaveProgress(int levelI, int bestNum)
    {
        SaveManager.SaveCurrentLevel(levelI);
        SaveManager.SaveBestiary(bestNum);
    }

    public void PlayLevel(bool levelContinue)
    {
        _uiManager.HideMenu();
        _uiManager.HideBestiary();
        _uiManager.HideInGameMenu();
        _uiManager.DeathScreen(false);
        Player.DeletePlayer();
        if (levelContinue)
        {
            GenerateLevel(SaveManager.LoadCurrentLevel());
        }
        else
        {
            GenerateLevel(_startLevelNum);
        }
    }

    IEnumerator ShiftTransform(float shift)
    {
        yield return new WaitForSeconds(.01f);
        _currentLevel.transform.position = 
            new Vector3(_currentLevel.transform.position.x + shift, 0f);
    }
    public void CloseLevel()
    {
        _uiManager.ShowMenu();
        _uiManager.HideBestiary();
        _uiManager.HideInGameMenu();

        Destroy(_currentLevel);
        _currentLevel = null;
        Player.DeletePlayer();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
