using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private List<string> _dialog = new List<string>();
    [SerializeField] private TextMeshProUGUI _dialogText;
    [SerializeField] private GameObject _dialogWindow;
    private int _currentDialogIndex;
    private GameObject _player;
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            _player = other.gameObject;
            // отобразить первую фразу диалога
            _currentDialogIndex = 0;
            _dialogWindow.SetActive(true);
            _player.GetComponent<Rigidbody2D>().simulated = false;
            _player.GetComponent<MovePlayer>().enabled = false;
            ShowCurrentDialog();
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            // отобразить следующую фразу диалога
            _currentDialogIndex++;
            ShowCurrentDialog();
        }
    }

    void ShowCurrentDialog() {
        if (_currentDialogIndex < _dialog.Count) {
            // отобразить текущую фразу диалога
            _dialogText.text = _dialog[_currentDialogIndex];
        } else {
            // завершить диалог
            EndDialog();
        }
    }

    void EndDialog() {
        // скрыть окно диалога
        _dialogWindow.SetActive(false);
        // включить движение игрока
        _player.GetComponent<Rigidbody2D>().simulated = true;
        _player.GetComponent<MovePlayer>().enabled = true;
        //playerMovement.enabled = true;
    }
}
