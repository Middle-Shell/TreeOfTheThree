using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _deathScreen;
    
    void Start()
    {
        PlayerStateEvent.PlayerDeathEvent += PlayerDeathScreen;
    }

    void PlayerDeathScreen()
    {
        PlayerStateEvent.PlayerDeathEvent -= PlayerDeathScreen;
        _deathScreen.SetActive(true);
        Invoke("ReloadScene", 2f);//для тестов, потом удалить
    }

    void ReloadScene()//для тестов, потом удалить
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
