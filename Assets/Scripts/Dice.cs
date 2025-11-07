using TMPro;
using UnityEngine;
using System.Collections;

public class Dice : MonoBehaviour
{
    [SerializeField] private Pawn _playerPawn;
    private bool _isRolling;
    [SerializeField] private TextMeshProUGUI _buttonText;
    private int _value;

    private void RollDice()
    {
        Debug.Log($"Le dé a fait {_value}");
        _playerPawn.TryMoving(_value);
    }

    private void IsRolling()
    {
        _value = Random.Range(1, 7);
        _buttonText.text = _value.ToString();
    }

    public void DrawDice()
    {
        StartCoroutine(Rolling(2f));
    }

    IEnumerator Rolling(float duration)
    {
        _isRolling = true;
        yield return new WaitForSeconds(duration);
        _isRolling = false;
        RollDice();
    }

    private void Update()
    {
        if (_isRolling) 
        { 
            IsRolling();
        }
    }
}
