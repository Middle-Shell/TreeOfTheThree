using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class UIDeadText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _deadText = null;
    [SerializeField] private List<string> _deadTexts = new List<string>();
    
    public void ShowDeadText()
    {
        _deadText.gameObject.SetActive(true);
        _deadText.text = _deadTexts[Random.Range(0, _deadTexts.Count)];
    }

    public void HideDeadText()
    {
        _deadText.gameObject.SetActive(false);
    }
}
