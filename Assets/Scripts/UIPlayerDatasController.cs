using TMPro;
using UnityEngine;

public class UIPlayerDatasController : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthText;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void UpdateHealth(float health)
    {
        _healthText.text = "Health : " + health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
