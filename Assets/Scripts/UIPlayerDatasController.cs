using System.Collections;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class UIPlayerDatasController : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private Image _fillImageHealth;
    [SerializeField] private GameObject _healthBlockHUD;

    [SerializeField] private TMP_Text _moneyText;

    [SerializeField] private TMP_Text _staminaText;
    [SerializeField] private Image _fillStamina;
    [SerializeField] private GameObject _staminaHUD;

    [SerializeField] private GameObject _diceBox;

    [SerializeField] private Image _healthMonsterDisplay;

    [SerializeField] private GameObject _DeathHUD;
    [SerializeField] private GameObject _nextLevelHUD;

    [SerializeField] private GameObject _duelResultHUD;
    [SerializeField] private TMP_Text _duelTextResult;
 
    [SerializeField] private PlayerDatas _playerDatas;

    /*public void Start()
    {
        
        UpdateHealth(true, _playerDatas._data._health);
        UpdateMoneyHUD();
    }*/


    public void LateStart(PlayerDatas playerdatas)
    {
        _playerDatas = playerdatas;
        UpdateHealth(true, _playerDatas._data._health);
        UpdateMoneyHUD();
    }

    public void UpdateHealth(bool isPlayer, float value)
    {
        if (isPlayer)
        {
            _fillImageHealth.fillAmount = value * 0.05f;
            _healthText.text = "Health : " + value.ToString();
        }
        else 
        {
            _healthMonsterDisplay.fillAmount = value / 10;
        }
    }

    public void SetFightingHUD(bool active)
    {
        _staminaHUD.SetActive(active);
        _diceBox.SetActive(!active);
    }

    public void SetDuelHUD(bool active)
    {
        _diceBox.SetActive(!active);
        _healthBlockHUD.SetActive(!active);
    }

    public IEnumerator DisplayDuelResult(string text)
    {
        yield return new WaitForSeconds(0.2f);
        _duelTextResult.text = text;
        _duelResultHUD.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        _duelResultHUD.SetActive(false);
    }

    public void UpdateStamina(float value)
    {
        _fillStamina.fillAmount = value / 100;
        _staminaText.text = "Stamina : " + math.floor(value).ToString() + "/100";
    }

    public void DisplayDeathHUD()
    {
        _DeathHUD.SetActive(true);
    }

    public void DisplayNextLevelHUD(int level)
    {
        _nextLevelHUD.SetActive(true);
        if (level == 1)
        {
            _playerDatas._data._attack += 2;
        }
        else if (level == 2)
        {
            UpdateMoney(200);
        }
    }

    public void UpdateMoney(int gain)
    {
        _playerDatas._data._money += gain;
        UpdateMoneyHUD();
        if (_playerDatas._data._money <= 0)
        {
            //cannot duel
        }
    }

    private void UpdateMoneyHUD()
    {
        _moneyText.text = "Money : " + _playerDatas._data._money.ToString();
    }
}
