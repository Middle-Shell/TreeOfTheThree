using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _deathScreen;

    [SerializeField] private GameObject _numberPotScreen;
    private int _numberPot = 0; //заменить на подгрузку из сохранения
    
    void Start()
    {
        PlayerStateEvent.PlayerDeathEvent += PlayerDeathScreen;
        PlayerStateEvent.PlayerCollectPotEvent += NumberPot;
    }

    void PlayerDeathScreen()
    {
        PlayerStateEvent.PlayerDeathEvent -= PlayerDeathScreen;
        _deathScreen.SetActive(true);
        Invoke("ReloadScene", 2f);//для тестов, потом удалить
    }

    void NumberPot()
    {
        var text = _numberPotScreen.GetComponent<TextMeshProUGUI>().text;
        _numberPot += 1;
        _numberPotScreen.GetComponent<TextMeshProUGUI>().text = _numberPot.ToString();
    }
    void ReloadScene()//для тестов, потом удалить
    {
        GameManager.SingletoneGameManager.GenerateLevel(1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
