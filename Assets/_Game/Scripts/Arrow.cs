using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        angle = Mathf.Atan2(_rigidbody2D.velocity.y, _rigidbody2D.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.isKinematic = true;
        Destroy(this.gameObject, 1f);
    }
}
