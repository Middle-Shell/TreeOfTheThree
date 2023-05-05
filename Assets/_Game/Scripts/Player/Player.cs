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
        print(isFree);
        if (SaveManager.LoadCurrentLevel() >= 4)
        {
            _player.GetComponent<RunPlayer>().enabled = !isFree;
            _player.GetComponent<MovePlayer>().enabled = isFree;
            _player.GetComponent<MovePlayer>().BlockY = isFree;
            CameraController.Instance.RunOver = false;
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
