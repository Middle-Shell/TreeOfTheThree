using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _deathScreen;

    [SerializeField] private Image _blackoutScreen;
    [SerializeField] private float _duration = 5.0f;

    [SerializeField] private GameObject _numberPotScreen;
    private int _numberPot = 0; //заменить на подгрузку из сохранения
    
    void Start()
    {
        PlayerStateEvent.PlayerDeathEvent += PlayerDeathScreen;
        PlayerStateEvent.PlayerCollectPotEvent += NumberPot;
        PlayerStateEvent.FinishMilestoneEvent += BlackOut;
    }

    void PlayerDeathScreen()
    {
        PlayerStateEvent.PlayerDeathEvent -= PlayerDeathScreen;
        _deathScreen.SetActive(true);
        GameManager.SingletoneGameManager.ReloadScene();//для тестов, потом удалить
    }

    void NumberPot()
    {
        var text = _numberPotScreen.GetComponent<TextMeshProUGUI>().text;
        _numberPot += 1;
        _numberPotScreen.GetComponent<TextMeshProUGUI>().text = _numberPot.ToString();
    }
    
    private IEnumerator BlackOut()
    {
        bool isBlack = true;
        float t = 0.0f;
        Color blackoutScreen = _blackoutScreen.color;
        while (true)
        {
            //Постепенно меняем альфа канал спрайтов
            var a = Mathf.Lerp(_blackoutScreen.color.a, (isBlack?1:0), t);
            blackoutScreen.a = a;
            _blackoutScreen.color = blackoutScreen;

            // Увеличиваем время на delta time, чтобы достичь нужного промежуточного спрайта через duration секунд
            t += Time.deltaTime / _duration;

            // Если достигли конца, то выходим из цикла
            if (t >= 1.0f)
            {
                if (!isBlack)
                {
                    break;
                }
                yield return new WaitForSeconds(1f);
                isBlack = false;
                t = 0.0f;
            }

            // Ждем один кадр
            yield return null;
        }
    }
}
