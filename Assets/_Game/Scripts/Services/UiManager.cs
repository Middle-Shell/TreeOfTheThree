using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject _continueButton = null;
    [SerializeField] private GameObject _continueButtonInGame = null;
    [SerializeField] private Bestiary _bestiary = null;
    [SerializeField] private GameObject _menu = null;
    [SerializeField] private GameObject _inGameMenu = null;
    [SerializeField] private GameObject _deathScreen;

    void Start()
    {
        PlayerStateEvent.PlayerDeathEvent += ShowInGameMenu;
        PlayerStateEvent.PlayerDeathEvent += HideContinueButtonInGame;
    }

    public void ReturnToMenu()
    {
        GameManager.SingletoneGameManager.CloseLevel();
    }

    public void DeathScreen(bool enable)
    {
        _deathScreen.SetActive(enable);
    }

    public void ShowBestiary()
    { 
        Time.timeScale = 0;
        _bestiary.gameObject.SetActive(true);
        _bestiary.ShowBestiary();
    }

    public void ShowMenu()
    {
        if (Player.IsPlayerNotNull)
        {
            ShowInGameMenu();
            return;
        }
        _menu.SetActive(true);

        if (SaveManager.LoadCurrentLevel() != 0)
        {
            _continueButton.SetActive(true);
        }
        else
            _continueButton.SetActive(false);
    }

    private void HideContinueButtonInGame()
    {
        _continueButtonInGame.SetActive(false);
    }
    public void ShowInGameMenu()
    {
        Time.timeScale = 0;
        _inGameMenu.SetActive(true);
    }

    public void HideInGameMenu()
    {
        Time.timeScale = 1;
        _continueButtonInGame.SetActive(true);
        _inGameMenu.SetActive(false);
    }

    public void HideMenu()
    {
        _menu.SetActive(false);
    }

    public void HideBestiary()
    {
        _bestiary.gameObject.SetActive(false);
    }
}