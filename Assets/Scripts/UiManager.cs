using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject _continueButton = null;
    [SerializeField] private Bestiary _bestiary = null;
    [SerializeField] private GameObject _menu = null;
    [SerializeField] private GameObject _inGameMenu = null;

    public void ShowBestiary()
    { 
        _bestiary.gameObject.SetActive(true);
        _bestiary.ShowBestiary();
    }

    public void ShowMenu()
    {
        _menu.SetActive(true);

        if (SaveManager.LoadCurrentLevel() != 0)
        {
            _continueButton.SetActive(true);
        }
        else
            _continueButton.SetActive(false);
    }
    public void ShowInGameMenu()
    {
        _inGameMenu.SetActive(true);
    }

    public void HideInGameMenu()
    {
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
