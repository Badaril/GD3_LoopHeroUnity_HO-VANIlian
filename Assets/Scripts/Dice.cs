using TMPro;
using UnityEngine;
using System.Collections;

public class Dice : MonoBehaviour
{
    [SerializeField] private Pawn _playerPawn;
    private bool _isRolling;
    [SerializeField] private TextMeshProUGUI _buttonText;

    private void RollDice()
    {
        int value = Random.Range(1, 7);
        _buttonText.text = value.ToString();
        Debug.Log($"Le dé a fait {value}");
        _playerPawn.TryMoving(value);
    }

    private void IsRolling()
    {
        int value = Random.Range(1, 7);
        _buttonText.text = value.ToString();
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
