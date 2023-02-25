using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    void OnMouseDown()
    {
        PlayerStateEvent.OnPlayerCollectPot();
        Destroy(gameObject);
    }
}
