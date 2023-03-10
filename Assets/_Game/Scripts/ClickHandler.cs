using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked");
    }
    /*
    void OnMouseDown()
    {
        PlayerStateEvent.OnPlayerCollectPot();
        Destroy(this.gameObject, 0.2f);
    }*/
}
