using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour
{
    void OnMouseDown()
    {
        PlayerStateEvent.OnPlayerCollectPot();
        Destroy(this.gameObject, 0.2f);
    }
}
