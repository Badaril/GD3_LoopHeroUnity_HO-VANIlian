using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerDatasController : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private Image _fillImageHealth;
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

    public void DisplayDeathHUD()
    {
        _DeathHUD.SetActive(true);
    }
}
