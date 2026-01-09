using TMPro;
using UnityEngine;
using System.Collections;


public class Dice : MonoBehaviour
{
    [SerializeField] private Pawn _playerPawn;
    private bool _isRolling;
    [SerializeField] private TextMeshProUGUI _buttonText;
    private int _value;
    [SerializeField] private int _maxValue;
    private bool _alreadyDrawed = false;
    [SerializeField] private GameObject _chooseDiceButton;

    public void RollDice()
    {
        Debug.Log($"Le dé a fait {_value}");
        _playerPawn.TryMoving(_value);
        _alreadyDrawed = false;
        _chooseDiceButton.SetActive(false);
    }

    private void IsRolling()
    {
        if (!(_alreadyDrawed)) {
            _value = Random.Range(1, _maxValue);
            _buttonText.text = _value.ToString();  
        }
    }

    public void DrawDice()
    {
        StartCoroutine(Rolling(1f));
    }

    IEnumerator Rolling(float duration)
    {
        _isRolling = true;
        yield return new WaitForSeconds(duration);
        _isRolling = false;
        _chooseDiceButton.SetActive(true);
        _alreadyDrawed = true;
    }

    private void Update()
    {
        if (_isRolling) 
        { 
            IsRolling();
        }
    }
}
