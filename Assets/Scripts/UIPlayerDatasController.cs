using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerDatasController : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private Image _fillImageHealth;
    [SerializeField] private TMP_Text _staminaText;
    [SerializeField] private Image _fillStamina;
    [SerializeField] private GameObject _staminaHUD;
    [SerializeField] private GameObject _diceBox;
    [SerializeField] private Image _healthMonsterDisplay;
    [SerializeField] private GameObject _DeathHUD;
    [SerializeField] private PlayerDatas _playerDatas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateHealth(true, _playerDatas._health);
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

    public void UpdateStamina(float value)
    {
        _fillStamina.fillAmount = value / 100;
        _staminaText.text = "Stamina : " + math.floor(value).ToString() + "/100";
    }

    public void DisplayDeathHUD()
    {
        _DeathHUD.SetActive(true);
    }
}
