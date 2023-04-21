using System.Collections;
using System.Collections.Generic;
using Assets._Game.Scripts.Enemy;
using UnityEngine;

public class VisibleController : MonoBehaviour
{
    private IEnemy _enemyController;

    void Start()
    {
        _enemyController = GetComponent<IEnemy>();
    }
    
    public void OnBecameVisible()
    {
        _enemyController.Active();
    }

    public void OnBecameInvisible()
    {
        _enemyController.Deactivate();
    }
}
