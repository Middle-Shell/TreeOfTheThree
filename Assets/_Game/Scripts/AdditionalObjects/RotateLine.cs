using UnityEngine;

public class RotateLine : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private bool toLeft = false;
    private float angle = 0f;

    void Update()
    {
        if (toLeft)
        {
            angle -= speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, angle, 180f);
        }
        else
        {
            angle += speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        if (Mathf.Abs(angle) >= 90f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
