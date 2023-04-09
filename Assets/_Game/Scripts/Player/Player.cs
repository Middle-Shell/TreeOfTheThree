using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static GameObject _player;

    void Start()
    {
        if (IsPlayerNotNull)
        {
            Destroy(gameObject);
            return;
        }
        CameraController.Instance.Player = transform;
        _player = gameObject;
        transform.parent = null;
    }

    public static void FreeMove(bool isFree)
    {
        if (SaveManager.LoadCurrentLevel() >= 3)
        {
            _player.GetComponent<RunPlayer>().enabled = !isFree;
            _player.GetComponent<MovePlayer>().enabled = isFree;
            _player.GetComponent<MovePlayer>().BlockY = isFree;
        }
        else
            CameraController.Instance.RunOver = !isFree;
    }
    
    public static bool IsPlayerNotNull => _player;

    public static void DeletePlayer()
    {
        Destroy(_player);
        _player = null;
    }
}
