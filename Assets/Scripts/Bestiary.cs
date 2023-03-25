using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bestiary : MonoBehaviour
{
    [SerializeField] private GameObject _glos = null;
    [SerializeField] private GameObject _page = null;
    [SerializeField] private GameObject _bestiary = null;
    [SerializeField] private List<TextMeshProUGUI> _nameButtons = new List<TextMeshProUGUI>();
    [Space(30)]
    [SerializeField] private List<string> _name = new List<string>();
    [SerializeField] private List<string> _text = new List<string>();
    [SerializeField] private List<Sprite> _image = new List<Sprite>();

    [Space(30)]
    [SerializeField] private TextMeshProUGUI _nameTMP = null;
    [SerializeField] private TextMeshProUGUI _textTMP = null;
    [SerializeField] private Image _imageUI = null;

    [Space(30)]
    [SerializeField] private string _wrongName = null;
    [SerializeField] private string _wrongText = null;
    [SerializeField] private Sprite _wrongImage = null;

    public void ShowBestiary()
    {
        int bestiaryPages = SaveManager.LoadBestiary();
        for (int i = 0; i < bestiaryPages; i++)
        {
            _nameButtons[i].text = _name[i];
        }

        for (int i = bestiaryPages; i < _nameButtons.Count; i++)
        {
            _nameButtons[i].text = _wrongText;
        }

        _bestiary.SetActive(true);
        _glos.SetActive(true);
        _page.SetActive(false);
    }

    public void ShowPage(int pageNumber)
    {
        int bestiaryPages = SaveManager.LoadBestiary();

        if (pageNumber > bestiaryPages || bestiaryPages == 0)
        {
            ChangeWrongUi();
        }
        else
        {
            ChangeUi(pageNumber);
        }

        _glos.SetActive(false);
        _page.SetActive(true);
    }

    private void ChangeWrongUi()
    {
        _nameTMP.text = _wrongName;
        _textTMP.text = _wrongText;
        _imageUI.sprite = _wrongImage;
    }

    private void ChangeUi(int pageNumber)
    {
        _nameTMP.text = _name[pageNumber];
        _textTMP.text = _text[pageNumber];
        _imageUI.sprite = _image[pageNumber];
    }
}
