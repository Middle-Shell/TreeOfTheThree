using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //[SerializeField] Vector2 offset = new Vector2(2f, 1f);
    
    [Header("Parameters")]
    [SerializeField] private GameObject Player;
    [SerializeField] [Range(0.5f, 7.5f)] private float movingSpeed = 5f;
    [SerializeField] private Vector3 _offserXYZ = new (4f, 0f, -500f);//-500 по Z что бы не было спрайтов уходящих за камеру

    void Start()
    {
    }

    private void FixedUpdate()
    {
        Vector3 target = Player.transform.position + _offserXYZ;

        transform.position = Vector3.Lerp(transform.position, target, movingSpeed * Time.deltaTime);
    }
}
