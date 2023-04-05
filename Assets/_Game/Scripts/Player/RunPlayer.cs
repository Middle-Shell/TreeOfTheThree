using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class RunPlayer : MonoBehaviour
{
    [Range(10f, 40f)] public const float Speed = 10;
    private Rigidbody2D _rbody;
    public int a = 10;
    private Vector2 _moveInput;



    void Awake()
    {
        _rbody = GetComponent<Rigidbody2D>();
        
        if(_rbody is null)
            Debug.LogError("Rigidbody is NULL");
    }
    void FixedUpdate()
    {
        _rbody.velocity = new Vector2( Speed, _rbody.velocity.y);
    

    }
}