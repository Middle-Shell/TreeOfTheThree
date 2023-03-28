using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static GameObject _player;
    
    void Start()
    {
        CameraController.Instance.Player = transform;
        print("camera");
        _player = gameObject;
        transform.parent = null;
    }

    public static void DeletePlayer()
    {
        Destroy(_player);
    }
}
