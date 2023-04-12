using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bestiary : MonoBehaviour
{
    [SerializeField] private Button _previusPage = null;
    [SerializeField] private Button _nextPage = null;
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
    [SerializeField] private List<string> _wrongNameButtons = null;
    [SerializeField] private List<string> _wrongName = null;
    [SerializeField] private List<string> _wrongText = null;
    [SerializeField] private List<Sprite> _wrongImage = null;
    


    private int currentPaheNumber = 0;
    public void ShowBestiary()
    {
        int bestiaryPages = SaveManager.LoadBestiary();
        for (int i = 0; i < bestiaryPages; i++)
        {
            _nameButtons[i].text = _name[i];
        }

        for (int i = bestiaryPages; i < _nameButtons.Count; i++)
        {
            _nameButtons[i].text = _wrongNameButtons[i];
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
            ChangeWrongUi(pageNumber);
        }
        else
        {
            ChangeUi(pageNumber);
        }

        _glos.SetActive(false);
        _page.SetActive(true);
    }

    private void ChangeWrongUi(int pageNumber)
    {
        _nameTMP.text = _wrongName[pageNumber];
        _textTMP.text = _wrongText[pageNumber];
        _imageUI.sprite = _wrongImage[pageNumber];

        currentPaheNumber = pageNumber;

        if (pageNumber == 0)
        {
            _previusPage.gameObject.SetActive(false);
        }
        else
        {
            _previusPage.gameObject.SetActive(true);
        }

        if (pageNumber == _name.Count-1)
        {
            _nextPage.gameObject.SetActive(false);
        }
        else
        {
            _nextPage.gameObject.SetActive(true);
        }
    }

    private void ChangeUi(int pageNumber)
    {
        _nameTMP.text = _name[pageNumber];
        _textTMP.text = _text[pageNumber];
        _imageUI.sprite = _image[pageNumber];

        currentPaheNumber = pageNumber;

        if (pageNumber == 0)
        {
            _previusPage.gameObject.SetActive(false);
        }
        else
        {
            _previusPage.gameObject.SetActive(true);
        }

        if (pageNumber == _name.Count-1)
        {
            _nextPage.gameObject.SetActive(false);
        }
        else
        {
            _nextPage.gameObject.SetActive(true);
        }
    }

    public void NextPage()
    {
        int bestiaryPages = SaveManager.LoadBestiary();

        if (currentPaheNumber + 1 > bestiaryPages || bestiaryPages == 0)
        {
            ChangeWrongUi(currentPaheNumber + 1);
        }
        else
        {
            ChangeUi(currentPaheNumber + 1);
        }

    }

    public void PreviusPage()
    {
        int bestiaryPages = SaveManager.LoadBestiary();

        if (currentPaheNumber - 1 > bestiaryPages || bestiaryPages == 0)
        {
            ChangeWrongUi(currentPaheNumber - 1);
        }
        else
        {
            ChangeUi(currentPaheNumber - 1);
        }

    }
}
